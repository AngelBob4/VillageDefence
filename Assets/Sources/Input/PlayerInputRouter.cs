using UnityEngine;

public class PlayerInputRouter
{
    private PlayerInput _playerInput;
    private PlayerMovement _playerMovement;

    public PlayerInputRouter(PlayerMovement playerMovement) 
    {
        _playerInput = new PlayerInput();
        _playerMovement = playerMovement;
    }

    public void Update()
    {
        Vector2 moveDirection = _playerInput.Player.Move.ReadValue<Vector2>();

        _playerMovement.ResetMoveDirection(moveDirection);
        _playerMovement.Rotate();
    }

    public void OnEnable()
    {
        _playerInput.Enable();
    }

    public void OnDisable()
    {
        _playerInput.Disable();
    }
}