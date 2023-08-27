using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackState : PlayerBaseState
{
    private readonly int AttackAnimationHash = Animator.StringToHash("Attack");
    private AnimatorStateInfo stateInfo;

    public PlayerAttackState(PlayerStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        if(!_stateMachine.playerAttack.canAttack)
        {
            OnRoamState();
            return;
        }
        HandleAttack();
    }

    private void HandleAttack()
    {
        _stateMachine.InputReader.OnPlayerAttackEvent.Raise();
        _stateMachine.RigidBody.velocity = new Vector2(0, _stateMachine.RigidBody.velocity.y);
        _stateMachine.Animator.Play(AttackAnimationHash);
    }

    public override void Tick(float deltaTime)
    {
        OnFinishAttackCheck();
    }

    private void OnFinishAttackCheck()
    {
        stateInfo = _stateMachine.Animator.GetCurrentAnimatorStateInfo(0);
        if (stateInfo.normalizedTime >= 1.0f)
        {
            OnRoamState();
        }
        
    }

    public override void Exit()
    {

    }

    public void OnRoamState()
    {
        _stateMachine.SwitchState(new PlayerRoamState(_stateMachine));
    }
}
