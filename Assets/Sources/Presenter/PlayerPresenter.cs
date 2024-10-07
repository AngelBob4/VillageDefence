public class PlayerPresenter : IPresenter
{
    private Player _player;
    private Game _game;

    public PlayerPresenter(Player player, Game game)
    {
        _player = player;
        _game = game;
    }

    public void Enable()
    {
        _player.Die += OnDie;
    }

    public void Disable()
    {
        _player.Die -= OnDie;
    }

    private void OnDie()
    {
        _game.HandlePlayerDeath();
    }
}