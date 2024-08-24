using UnityEngine;

public class EnemyAnimator
{
    private const string TriggerShoot = "Shoot";

    private Animator _animator;

    public void Init(Animator animator)
    {
        _animator = animator;
    }

    public void Shoot() => _animator.SetTrigger(TriggerShoot);
}
