using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRoamState : PlayerBaseState
{
    private readonly int RoamSpeedHash = Animator.StringToHash("RoamSpeed");
    private readonly int RoamBlendTreeHash = Animator.StringToHash("RoamBlendTree");

    private readonly int GroundLayerMask = LayerMask.GetMask("Ground");

    public PlayerRoamState(PlayerStateMachine stateMachine) : base(stateMachine){}

    public override void Enter()
    {
        _stateMachine.InputReader.InputState(true);
        _stateMachine.Animator.Play(RoamBlendTreeHash);

        _stateMachine.InputReader.onJumpEvent += OnJump;
        _stateMachine.InputReader.onAttackEvent += OnAttack;
    }

    public override void Tick(float deltaTime)
    {
        HandleMovement(deltaTime);
    }

    public override void Exit()
    {
        _stateMachine.InputReader.onJumpEvent -= OnJump;
        _stateMachine.InputReader.onAttackEvent -= OnAttack;
    }

    private void HandleMovement(float deltaTime)
    {
        Vector2 movement = CalculateMovement(deltaTime);

        if (movement == Vector2.zero)
        {
            _stateMachine.Animator.SetFloat(RoamSpeedHash, 0, 0.1f, deltaTime);
            return;
        }
        _stateMachine.Animator.SetFloat(RoamSpeedHash, 1, 0.1f, deltaTime);
        if (movement.x > 0) _stateMachine.PlayerSprite.localScale = new Vector3(1, 1, 1);
        else if (movement.x < 0) _stateMachine.PlayerSprite.localScale = new Vector3(-1, 1, 1);
    }

    private Vector2 CalculateMovement(float deltaTime)
    {
        Vector2 movement = new Vector2();
        movement.x = _stateMachine.joyStick.Horizontal * deltaTime * _stateMachine.MovementSpeed;
#if UNITY_EDITOR
        movement.x = _stateMachine.InputReader.MovementValue.x * deltaTime * _stateMachine.MovementSpeed;
#endif
        movement.y = _stateMachine.RigidBody.velocity.y;
        _stateMachine.RigidBody.velocity = (movement);
        return movement;
    }

    public void OnJump()
    {
        if (_stateMachine.FeetCollider.IsTouchingLayers(GroundLayerMask)) _stateMachine.canJump = true;
        if (!_stateMachine.canJump) return;
        _stateMachine.canJump = false;
        _stateMachine.SwitchState(new PlayerJumpState(_stateMachine));
    }

    public void OnAttack()
    {
        _stateMachine.SwitchState(new PlayerAttackState(_stateMachine));
    }


}
