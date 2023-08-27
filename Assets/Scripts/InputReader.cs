using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Sirenix.OdinInspector;
using System;

[RequireComponent(typeof(PlayerAttack))]
public class InputReader : MonoBehaviour, Controls.IPlayerActions
{
    [BoxGroup("Event")]
    [SerializeField] private GameEventNoParam _onPlayerAttackEvent,_onPlayerJumpEvent;
    [BoxGroup("Bool")]
    [SerializeField] private bool _enableInput = true;
    public GameEventNoParam OnPlayerJumpEvent => _onPlayerJumpEvent;
    public GameEventNoParam OnPlayerAttackEvent => _onPlayerAttackEvent;

    public Vector2 MovementValue { get; private set; }
    private Controls _controls;
    public event Action onJumpEvent;
    public event Action onAttackEvent;

    private void Start()
    {
        _controls = new Controls();
        _controls.Player.SetCallbacks(this);
        _controls.Player.Enable();
    }

    private void OnDestroy()
    {
        if (_controls == null) return;
        _controls.Player.Disable();
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if (!context.performed || !_enableInput) return;
        onAttackEvent?.Invoke();
        _onPlayerAttackEvent.Raise();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (!context.performed || !_enableInput) return;
        onJumpEvent?.Invoke();
    }    
    
    public void OnAttackButton()
    {
        if(TryGetComponent<PlayerAttack>(out PlayerAttack playerAttack))
        if (!_enableInput) return;
        onAttackEvent?.Invoke();
    }


    public void OnJumpButton()
    {
        if (!_enableInput) return;
        onJumpEvent?.Invoke();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if (!_enableInput) return;
        MovementValue = context.ReadValue<Vector2>();
    }

    public void InputState(bool state)
    {
        _enableInput = state; 
    }
}
