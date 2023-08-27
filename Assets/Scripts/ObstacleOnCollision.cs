using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class ObstacleOnCollision : MonoBehaviour
{
    [BoxGroup("Variables")]
    [SerializeField] private int _damageValue = 100;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            if (!collision.TryGetComponent<PlayerHealth>(out PlayerHealth playerHealth)) return;
            if (playerHealth.CurrentHealth <= 0) return;
            playerHealth.TakeDamage(_damageValue);
        }
    }
}
