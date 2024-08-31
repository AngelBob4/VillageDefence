using UnityEngine;

[RequireComponent(typeof(CapsuleCollider))]
public class EnemyAttackZone : MonoBehaviour
{
    private Player _target;
    private EnemyAnimator _animator;
    private float _damage = 10f;
    private bool _isAttacking = false;

    public void Init(EnemyAnimator animator)
    {
        _animator = animator;
    }

    private void OnTriggerStay(Collider other)
    {
        if (_isAttacking)
            return;

        if (other.TryGetComponent(out Player player))
        {
            _target = player;
            _isAttacking = true;
            _animator.Shoot();
        }
    }

    public void HitPlayer()
    {
        _target.GetDamage(_damage);
        _isAttacking = false;
    }
}