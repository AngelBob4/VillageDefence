using UnityEngine;

[RequireComponent(typeof(CapsuleCollider))]
public class EnemyAttackZone : MonoBehaviour
{
    private Player _target;
    private EnemyAnimator _animator;
    private float _damage = 10f;

    public void Init(EnemyAnimator animator)
    {
        _animator = animator;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            _target = player;
            _animator.Shoot();
        }
    }

    public void HitPlayer()
    {
        _target.GetDamage(_damage);
    }
}