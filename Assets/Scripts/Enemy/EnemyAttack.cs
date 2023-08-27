using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class EnemyAttack : MonoBehaviour
{
    [BoxGroup("Event")]
    [SerializeField] GameEventNoParam _onEnemyAttackPlayerEvent;
    [BoxGroup("Damage Value")]
    [SerializeField] private int _damage = 10;
    [BoxGroup("Cooldown To Next Attack")]
    [SerializeField] private float _attackCooldown = 3f;
    [BoxGroup("Variables")]
    [SerializeField] private bool _isGroundEnemy = false;
    [ShowIf("_isGroundEnemy")]
    [SerializeField] private Animator _groundEnemyAnimator;
    private float _timeSinceLastAttack;
    private bool _canAttack;
    private GameObject _playerTarget;
    private AnimatorStateInfo stateInfo;

    private readonly int AttackAnimationHash = Animator.StringToHash("Attack Ground Enemy");
    private readonly int IdleAnimationHash = Animator.StringToHash("Idle Ground Enemy");

    private void Start()
    {
        _canAttack = true;
    }

    private void Update()
    {
        CooldownHandler();
    }

    private void CooldownHandler()
    {
        _timeSinceLastAttack += Time.deltaTime;
        if (_playerTarget == null) return;
        float distance = Vector2.Distance(transform.position, _playerTarget.transform.position);
        if (distance > 2) return;
        if (_isGroundEnemy) OnFinishAttackCheck();
        if (_timeSinceLastAttack >= _attackCooldown)
        {
            _canAttack = true;
            _timeSinceLastAttack = 0f;
            OnEnemyAttack();
        }
    }

    public void OnEnemyAttack()
    {
        if (!_canAttack) return;
        if (_isGroundEnemy) _groundEnemyAnimator.Play(AttackAnimationHash);
        _canAttack = false;
        if (!_playerTarget.TryGetComponent<PlayerHealth>(out PlayerHealth playerHealth)) return;
        playerHealth.TakeDamage(_damage);
        _onEnemyAttackPlayerEvent.Raise();

    }

    private void OnFinishAttackCheck()
    {
        stateInfo = _groundEnemyAnimator.GetCurrentAnimatorStateInfo(0);
        if (stateInfo.normalizedTime >= 1.0f)
        {
            _groundEnemyAnimator.Play(IdleAnimationHash);
        }

    }

    public void GetTargetPlayer(Component sender, object data)
    {
        if (data is GameObject)
        {
            _playerTarget = (GameObject)data;
        }
    }
}
