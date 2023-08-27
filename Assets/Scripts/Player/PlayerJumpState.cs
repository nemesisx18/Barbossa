using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerBaseState
{
    private readonly int JumpAnimationHash = Animator.StringToHash("Jump");
    private readonly int GroundLayerMask = LayerMask.GetMask("Ground");

    public PlayerJumpState(PlayerStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        HandleJump();
        _stateMachine.InputReader.onAttackEvent += OnAttack;
    }

    private void HandleJump()
    {
        _stateMachine.InputReader.OnPlayerJumpEvent.Raise();
        _stateMachine.Animator.Play(JumpAnimationHash);
        _stateMachine.RigidBody.velocity += new Vector2(0, _stateMachine.JumpSpeed);
    }

    public override void Tick(float deltaTime)
    {
        HandleMovement(deltaTime);
        GroundCheck();
    }

    private void GroundCheck()
    {
        if (_stateMachine.RigidBody.velocity.y > 0.1f) return;
        if (_stateMachine.FeetCollider.IsTouchingLayers(GroundLayerMask))
        {
            _stateMachine.canJump = true;
            OnRoamState();
        }
    }

    public override void Exit()
    {
        _stateMachine.InputReader.onAttackEvent -= OnAttack;
    }

    private void HandleMovement(float deltaTime)
    {
        Vector2 movement = CalculateMovement(deltaTime);

        if (movement == Vector2.zero)
        {
            return;
        }
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

    public void OnRoamState()
    {
        _stateMachine.SwitchState(new PlayerRoamState(_stateMachine));
    }

    public void OnAttack()
    {
        _stateMachine.SwitchState(new PlayerAttackState(_stateMachine));
    }


}
