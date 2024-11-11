public class PlayerPresenter : IPresenter
{
    private Player _player;
    private Game _game;
    private PauseService _pauseService;
    private bool _isDied;

    public PlayerPresenter(Player player, Game game, PauseService pauseService)
    {
        _pauseService = pauseService;
        _player = player;
        _game = game;
    }

    public void Enable()
    {
        _isDied = false;
        _player.Died += OnDie;
        _player.Revived += OnRevive;
    }

    public void Disable()
    {
        _player.Died -= OnDie; 
        _player.Revived -= OnRevive;

        if (_isDied)
            _pauseService.Unpause(_player.gameObject);
    }

    private void OnDie()
    {
        _isDied = true;
        _pauseService.Pause(_player.gameObject);
        _game.HandlePlayerDeath();
    }

    private void OnRevive()
    {
        _isDied = false;
        _pauseService.Unpause(_player.gameObject);
    }
}