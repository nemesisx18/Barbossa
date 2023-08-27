using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class EnemyStateMachine : StateMachine
{
    [field: SerializeField] public EnemyDetector enemyDetector { get; private set; } 
    [field: SerializeField] public SpriteRenderer enemySprite { get; private set; }
    [field: SerializeField] public Rigidbody2D enemyRb { get; private set; }
    [field: SerializeField] public Transform leftPoint { get; private set; }
    [field: SerializeField] public Transform rightPoint { get; private set; }
    [field: SerializeField] public Animator Animator { get; private set; }
    [field: SerializeField] public float moveSpeed { get; private set; }
    [field: SerializeField] public float stoppingDistance { get; private set; }
    [field: SerializeField] public bool isGroundEnemy { get; private set; }

    private void Start()
    {
        SwitchState(new EnemyPatrolState(this));
    }
}
