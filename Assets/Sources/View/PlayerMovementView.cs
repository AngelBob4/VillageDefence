using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovementView : MonoBehaviour
{
    private Player _player;
    private CharacterController _characterController;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        _characterController.Move(_player.MovementDirection * Time.deltaTime);
    }

    public void Init(Player player)
    {
        _player = player;
    }
}