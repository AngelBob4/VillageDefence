using UnityEngine;
using UnityEngine.UI;

public class GameCompositeRoot : CompositeRoot
{
    [SerializeField] private Game _game;
    [SerializeField] private EnemyGenerator _enemyGenerator;
    [SerializeField] private StartScreen _startScreen;
    [SerializeField] private EndGameScreen _endGameScreen;
    [SerializeField] private Button _startButton;
    [SerializeField] private Button _endGameButton;

    public override void Compose()
    {
        _startScreen.Init(_startButton);
        _endGameScreen.Init(_endGameButton);
        _game.Init(_enemyGenerator, _startScreen, _endGameScreen);
    }
}