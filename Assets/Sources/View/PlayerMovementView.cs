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
        Vector3 motion = _playerMovement.MovementDirection * Time.deltaTime * _playerMovement.MovementSpeed;

        _characterController.Move(motion);
        transform.LookAt(_playerMovement.PositionToRotate);
    }

    public void Init(PlayerMovement playerMovement)
    {
        _playerMovement = playerMovement;
    }
}