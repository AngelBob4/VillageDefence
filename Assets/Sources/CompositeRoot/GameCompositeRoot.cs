using UnityEngine;
using UnityEngine.UI;

public class GameCompositeRoot : CompositeRoot
{
    [SerializeField] private Game _game;
    [SerializeField] private EndGameScreen _endGameScreen;
    [SerializeField] private UpgradeScreen _upgradeScreen;
    [SerializeField] private Button _endGameButton;
    [SerializeField] private Player _player;
    [SerializeField] private EnemyFactory _enemyFactory;
    [SerializeField] private GameAudio _gameAudio;

    public override void Compose()
    {
        _endGameScreen.Init(_endGameButton);
        _upgradeScreen.Init(_player);
        _game.Init(_endGameScreen, _upgradeScreen, _enemyFactory, _gameAudio);
    }
}