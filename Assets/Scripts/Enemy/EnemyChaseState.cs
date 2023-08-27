using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChaseState : EnemyBaseState
{
    public EnemyChaseState(EnemyStateMachine stateMachine) : base(stateMachine){}
    private readonly int WalkAnimationHash = Animator.StringToHash("Walk Ground Enemy");
    private Vector3 _initPos;

    public override void Enter()
    {
        if(_stateMachine.isGroundEnemy)_stateMachine.Animator.Play(WalkAnimationHash);
        _initPos = _stateMachine.gameObject.transform.position;
    }

    public override void Tick(float deltaTime)
    {
        HandleChase();
    }

    private void HandleChase()
    {
        if (_stateMachine.enemyDetector.targetInDistance != null)
        {
            float distance = Vector2.Distance(_stateMachine.transform.position, _stateMachine.enemyDetector.targetInDistance.position);

            if (distance > _stateMachine.stoppingDistance)
            {
                MoveToDestinatedPosition(_stateMachine.enemyDetector.targetInDistance.position);
                FlipSpriteHandler(_stateMachine.enemyDetector.targetInDistance.position);
            }
            else
            {
                Debug.Log("target but stopped");
                _stateMachine.enemyRb.velocity = Vector2.zero;
            }
        }
        else
        {
            float distanceToInit = Vector2.Distance(_stateMachine.transform.position, _initPos);
            if (distanceToInit > 0.1f)
            {
                MoveToDestinatedPosition(_initPos);
                FlipSpriteHandler(_initPos);
            }
            else
            {
                Debug.Log("not target but stopped");
                _stateMachine.enemyRb.velocity = Vector2.zero;
                OnBackToPatrolState();
            }
        }
    }

    private void FlipSpriteHandler(Vector3 destinatedPos)
    {
        if (_stateMachine.transform.position.x > destinatedPos.x)
        {
            _stateMachine.enemySprite.flipX = true;
        }
        else
        {
            _stateMachine.enemySprite.flipX = false;
        }
    }

    private void MoveToDestinatedPosition(Vector3 destinatedPos)
    {
        Vector2 direction = (destinatedPos - _stateMachine.transform.position).normalized;
        if(_stateMachine.isGroundEnemy)
        {
            _stateMachine.Animator.Play(WalkAnimationHash);
            _stateMachine.enemyRb.velocity = new Vector3(direction.x, 0, 0) * _stateMachine.moveSpeed * 1.5f;
        }
        else
        {
            _stateMachine.enemyRb.velocity = direction * _stateMachine.moveSpeed * 1.5f;
        }
    }

    private void OnBackToPatrolState()
    {
        _stateMachine.SwitchState(new EnemyPatrolState(_stateMachine));
    }

    public override void Exit()
    {

    }


}
