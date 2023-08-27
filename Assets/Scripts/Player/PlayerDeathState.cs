using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeathState : PlayerBaseState
{
    private readonly int DeathAnimationHash = Animator.StringToHash("Death");

    public PlayerDeathState(PlayerStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        _stateMachine.RigidBody.velocity = Vector3.zero;
        _stateMachine.InputReader.InputState(false);
        HandleDeath();
    }

    private void HandleDeath()
    {
        _stateMachine.Animator.Play(DeathAnimationHash);
    }

    public override void Tick(float deltaTime)
    {
    }

    public override void Exit()
    {

    }

}
