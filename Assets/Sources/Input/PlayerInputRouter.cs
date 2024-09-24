using Agava.WebUtility;
using UnityEngine;

public class PlayerInputRouter
{
    private PlayerInput _playerInput;
    private PlayerMovement _playerMovement;
    private Joystick _joystick;

    public PlayerInputRouter(PlayerMovement playerMovement, Joystick joystick) 
    {
        _joystick = joystick;
        _playerInput = new PlayerInput();
        _playerMovement = playerMovement;
        
        if (Device.IsMobile)
            joystick.gameObject.SetActive(true);
    }

    public void Update()
    {
        Vector2 moveDirection;

        if (Device.IsMobile)
            moveDirection = _joystick.Direction;
        else
            moveDirection = _playerInput.Player.Move.ReadValue<Vector2>();

        moveDirection.Normalize();

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