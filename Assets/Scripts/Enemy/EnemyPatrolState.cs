using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrolState : EnemyBaseState
{
    public EnemyPatrolState(EnemyStateMachine stateMachine) : base(stateMachine) { }

    private readonly int WalkAnimationHash = Animator.StringToHash("Walk Ground Enemy");
    private bool movingRight = true;

    public override void Enter()
    {
        if (_stateMachine.rightPoint == null || _stateMachine.leftPoint == null) return;
        if (_stateMachine.isGroundEnemy) _stateMachine.Animator.Play(WalkAnimationHash);
        if (_stateMachine.leftPoint.parent != null) _stateMachine.leftPoint.SetParent(null);
        if (_stateMachine.rightPoint.parent != null) _stateMachine.rightPoint.SetParent(null);
    }
    public override void Tick(float deltaTime)
    {
        HandlePatrol();
    }

    private void HandlePatrol()
    {
        if (_stateMachine.rightPoint == null || _stateMachine.leftPoint == null)
        {
            OnPlayerDetected();
            return;
        }

        if (_stateMachine.transform.position.x > _stateMachine.rightPoint.position.x)
        {
            movingRight = false;
            _stateMachine.enemySprite.flipX = true;
        }
        else if (_stateMachine.transform.position.x < _stateMachine.leftPoint.position.x)
        {
            movingRight = true;
            _stateMachine.enemySprite.flipX = false;
        }

        if (movingRight)
        {
            _stateMachine.transform.position = new Vector2(_stateMachine.transform.position.x + _stateMachine.moveSpeed * Time.deltaTime, _stateMachine.transform.position.y);
        }
        else
        {
            _stateMachine.transform.position = new Vector2(_stateMachine.transform.position.x - _stateMachine.moveSpeed * Time.deltaTime, _stateMachine.transform.position.y);
        }

        OnPlayerDetected();
    }

    private void OnPlayerDetected()
    {
        if (_stateMachine.enemyDetector.targetInDistance == null) return;
        _stateMachine.SwitchState(new EnemyChaseState(_stateMachine));
    }

    public override void Exit()
    {
        
    }

}
