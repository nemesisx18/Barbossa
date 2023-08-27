using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Sirenix.OdinInspector;

public class EnemyHealth : HealthSystem,IDamageable
{
    [BoxGroup("Script Reference")]
    [SerializeField] private ObjectId _objectsId;
    [BoxGroup("SO")]
    [SerializeField] private CollectiblesManager _enemiesManager;
    [BoxGroup("SO")]
    [SerializeField] private PlayerDataScriptableObject _playerData;
    [BoxGroup("UI Healthbar Reference")]
    [SerializeField] private TextMeshProUGUI _healthText;
    [BoxGroup("UI Healthbar Reference")]
    [SerializeField] private Image _healthBarFill;

    public bool isBoss;
    [ShowIf("isBoss")]
    [BoxGroup("Event")]
    [SerializeField] private GameEventNoParam _onBossDefeatedEvent;

    public bool isFinalBoss;
    [ShowIf("isFinalBoss")]
    [SerializeField] private UI_Transisiton _transition;
    [ShowIf("isFinalBoss")]
    [SerializeField] private GameEventNoParam _onFinalBossDefeatedEvent;

    public override void Start()
    {
        base.Start();
        if (_enemiesManager.IsCollected(_objectsId.id))
        {
            gameObject.SetActive(false);
        }
    }

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        ChangeUIHealthBarOnTakeDamage();

        if (CurrentHealth <= 0)
        {
            gameObject.SetActive(false);
            _enemiesManager.CollectCollectible(_objectsId);
            if(isFinalBoss)
            {
                if (_transition == null) return;
                _onFinalBossDefeatedEvent.Raise();
                _transition.BeginTransition();
            }
            else
            {
                if (_onBossDefeatedEvent == null) return;
                _playerData.UnlockedLevel++;
                PlayerPrefs.SetInt("SavedLevel",_playerData.UnlockedLevel);
                _onBossDefeatedEvent.Raise();
            }

        }
            
    }

    private void ChangeUIHealthBarOnTakeDamage()
    {
        int amount = CurrentHealth;
        _healthText.text = amount.ToString();
        _healthBarFill.fillAmount = (float)amount / _maxHealth;
    }
}
