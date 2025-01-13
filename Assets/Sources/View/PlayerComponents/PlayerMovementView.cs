using Model.PlayerComponents;
using UnityEngine;

namespace View.PlayerComponents
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerMovementView : MonoBehaviour
    {
        private PlayerMovement _playerMovement;
        private CharacterController _characterController;
        private Transform _body;

        private void Awake()
        {
            _characterController = GetComponent<CharacterController>();
        }

        private void Update()
        {
            Vector3 motion = _playerMovement.MovementDirection * _playerMovement.MovementSpeed * Time.deltaTime;

            _characterController.Move(motion);
            _body.LookAt(_playerMovement.PositionToRotate);

            if (_characterController.isGrounded == false)
            {
                Vector3 gravity = Physics.gravity * Time.deltaTime;
                _characterController.Move(gravity);
            }
        }

        public void Init(PlayerMovement playerMovement, Transform body)
        {
            _playerMovement = playerMovement;
            _body = body;
        }
    }
}