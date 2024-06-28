using UnityEngine;

public class PlayerCompositeRoot : MonoBehaviour
{
    [SerializeField] private PlayerMovementView _playerMovementView;

    private Player _player;
    private PlayerMovement _playerMovement;
    private PlayerInputRouter _playerInputRouter;

    private void Awake()
    {
        _player = new Player();
        _playerMovement = new PlayerMovement(_player);
        _playerInputRouter = new PlayerInputRouter(_playerMovement);

        _playerMovementView.Init(_player);
    }

    private void Update()
    {
        _playerInputRouter.Update();
    }

    private void OnEnable()
    {
        _playerInputRouter.OnEnable();
    }

    private void OnDisable()
    {
        _playerInputRouter.OnDisable();
    }
}