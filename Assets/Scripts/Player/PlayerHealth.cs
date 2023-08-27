using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class PlayerHealth : HealthSystem, IHealable, IDamageable
{
    [BoxGroup("SO")]
    [SerializeField] private PlayerDataScriptableObject _playerData;
    [BoxGroup("Events")]
    [SerializeField] protected GameEvent _onPlayerHealthChanged;
    [BoxGroup("Events")]
    [SerializeField] protected GameEventNoParam _onPlayerDeathEvent,_onRestartSceneEvent,_onDisplayGameOverUI;
    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        _onPlayerHealthChanged.Raise(this, CurrentHealth);

        if (CurrentHealth <= 0)
        {
            Death();
        }
    }

    public void Heal(int amount)
    {
        CurrentHealth += amount;
        _onPlayerHealthChanged.Raise(this, CurrentHealth);
    }

    public void Death()
    {
        if (!TryGetComponent<PlayerStateMachine>(out PlayerStateMachine playerStateMachine)) return;
        playerStateMachine.SwitchState(new PlayerDeathState(playerStateMachine));
        if (_playerData.TotalLifePoint <= 0)
        {
            _onDisplayGameOverUI.Raise();
            _playerData.ResetData();
            return;
        }
        _playerData.TotalLifePoint--;
        _onPlayerDeathEvent.Raise();
        StartCoroutine(OnRestartSceneAfterDeath());
    }

    IEnumerator OnRestartSceneAfterDeath()
    {
        yield return new WaitForSeconds(0.5f);
        _onRestartSceneEvent.Raise();
    }
}
