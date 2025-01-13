using UnityEngine;

namespace Model.PlayerComponents
{
    public class PlayerAnimator
    {
        private const string TriggerShoot = "Shoot";
        private const string FloatSpeed = "Speed";

        private Animator _animator;
        private PlayerMovement _playerMovement;

        public void Init(Animator animator, PlayerMovement playerMovement)
        {
            _animator = animator;
            _playerMovement = playerMovement;
        }

        public void Update()
        {
            Moving();
        }

        public void Moving()
        {
            float speed = _playerMovement.MovementDirection.magnitude;
            _animator.SetFloat(FloatSpeed, speed);
        }

        public void Shoot() => _animator.SetTrigger(TriggerShoot);
    }
}