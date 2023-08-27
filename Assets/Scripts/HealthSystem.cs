using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Sirenix.OdinInspector;

public class HealthSystem : MonoBehaviour, IDamageable
{
    [BoxGroup("Variables")]
    [SerializeField] protected int _maxHealth = 100, _currentHealth;
    public int CurrentHealth
    {
        get => _currentHealth;
        set
        {
            _currentHealth = value;
            if (_currentHealth <= 0)
            {
                _currentHealth = 0;
            }

            if (_currentHealth > _maxHealth)
            {
                _currentHealth = _maxHealth;
            }
            
        }
    }

    public virtual void Start()
    {
        CurrentHealth = _maxHealth;
    }

    public virtual void TakeDamage(int damage)
    {
        CurrentHealth -= damage;
    }
}