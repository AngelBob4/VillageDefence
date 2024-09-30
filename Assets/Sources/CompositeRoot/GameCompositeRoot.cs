using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameCompositeRoot : CompositeRoot
{
    [SerializeField] private Game _game;
    [SerializeField] private EndGameScreen _endGameScreen;
    [SerializeField] private UpgradeScreenView _upgradeScreenView;
    [SerializeField] private Button _endGameButton;
    [SerializeField] private Player _player;
    [SerializeField] private EnemyGeneratorView _enemyGeneratorView;
    [SerializeField] private GameAudio _gameAudio;
    [SerializeField] private AddScore _addScore;
    [SerializeField] private LeaderboardView _leaderboardView;

    [Header("Upgrade screen")]
    [SerializeField] private Sprite _upgradeDamage;
    [SerializeField] private Sprite _upgradeRegeneration;
    [SerializeField] private Sprite _upgradeLifesteal;
    [SerializeField] private List<UpgradeButton> _upgradeButtons;

    private PauseService _pauseService;

    public override void Compose()
    {
        _pauseService = new PauseService();

        EndGamePresenter endGamePresenter = new EndGamePresenter(_endGameScreen);
        UpgradeScreen upgradeScreen = new UpgradeScreen(_pauseService, _player, _upgradeDamage, _upgradeRegeneration, _upgradeLifesteal, _upgradeScreenView, _upgradeButtons);
        UpgradeScreenPresenter upgradeScreenPresenter = new UpgradeScreenPresenter(_upgradeScreenView, upgradeScreen, _upgradeButtons);
        _endGameScreen.Init(endGamePresenter);
        _upgradeScreenView.Init(upgradeScreenPresenter);
        _game.Init(_endGameScreen, upgradeScreen, _enemyGeneratorView, _gameAudio, _addScore, _leaderboardView);
    }
}