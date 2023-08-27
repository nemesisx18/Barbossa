using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    [field:SerializeField] public PlayerAttack playerAttack { get; private set; }
    [field:SerializeField] public InputReader InputReader { get; private set; }
    [field:SerializeField] public Joystick joyStick { get; private set; }
    [field:SerializeField] public Rigidbody2D RigidBody { get; private set; }
    [field: SerializeField] public CapsuleCollider2D FeetCollider { get; private set; }
    [field: SerializeField] public Transform PlayerSprite { get; private set; }
    [field: SerializeField] public Animator Animator { get; private set; }
    [field:SerializeField] public float MovementSpeed { get; private set; }
    [field:SerializeField] public float JumpSpeed { get; private set; }
    [field: SerializeField] public bool canJump;

    private void Start()
    {
        canJump = true;
        SwitchState(new PlayerRoamState(this));
    }
}
