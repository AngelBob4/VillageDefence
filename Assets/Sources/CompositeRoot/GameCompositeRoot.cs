using UnityEngine;
using UnityEngine.UI;

public class GameCompositeRoot : CompositeRoot
{
    [SerializeField] private Game _game;
    [SerializeField] private EnemyGeneratorCompositeRoot _enemyGeneratorCompositeRoot;
    [SerializeField] private StartScreen _startScreen;
    [SerializeField] private EndGameScreen _endGameScreen;
    [SerializeField] private UpgradeScreen _upgradeScreen;
    [SerializeField] private Button _startButton;
    [SerializeField] private Button _endGameButton;
    [SerializeField] private Player _player;

    public override void Compose()
    {
        _startScreen.Init(_startButton);
        _endGameScreen.Init(_endGameButton);
        _upgradeScreen.Init(_player);
        _game.Init(_enemyGeneratorCompositeRoot, _startScreen, _endGameScreen, _upgradeScreen);
    }
}