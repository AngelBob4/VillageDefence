using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovementView : MonoBehaviour
{
    private PlayerMovement _playerMovement;
    private CharacterController _characterController;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Vector3 motion = _playerMovement.MovementDirection * _playerMovement.MovementSpeed * Time.deltaTime;

        _characterController.Move(motion);
        transform.LookAt(_playerMovement.PositionToRotate);

        if (_characterController.isGrounded == false)
        {
            Vector3 gravity = Physics.gravity * Time.deltaTime;
            _characterController.Move(gravity);
        }
    }

    public void Init(PlayerMovement playerMovement)
    {
        _playerMovement = playerMovement;
    }
}