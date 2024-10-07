using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameCompositeRoot : CompositeRoot
{
    [Header("Enemy generator")]
    [SerializeField] private Transform _enemyContainer;
    [SerializeField] private Enemy _template;
    [SerializeField] private EnemyGeneratorView _enemyGeneratorView;
    [SerializeField] private Particle _hit;
    [SerializeField] private ParticleSystem _death;
    [SerializeField] private EnemyFactory _enemyFactory;
    [SerializeField] private TimeToWave _timeToWave;
    [SerializeField] private VideoAdvertisement _videoAdvertisement;
    [SerializeField] private ProgressionSlider _progressionSlider;
    [SerializeField] private Text _waveCompleted;

    [Header("Game views")]
    [SerializeField] private VideoAdvertisement _videoAdd;
    [SerializeField] private EndGameScreen _endGameScreen;
    [SerializeField] private UpgradeScreenView _upgradeScreenView;
    [SerializeField] private Button _endGameButton;
    [SerializeField] private Player _player;
    [SerializeField] private GameAudio _gameAudio;
    [SerializeField] private AddScore _addScore;
    [SerializeField] private LeaderboardView _leaderboardView;
    [SerializeField] private CheckingFocus _checkingFocus;

    [Header("Leaderboard")]
    [SerializeField] private AuthorizationErrorView _authorizationErrorView;
    [SerializeField] private AuthorizationOfferView _authorizationOfferView;
    [SerializeField] private Leaderboard _leaderboard;

    [Header("Screen of healper")]
    [SerializeField] private Button _exitButton;
    [SerializeField] private ScreenOfGameHelperView _screenOfGameHelperView;

    [Header("Upgrade screen")]
    [SerializeField] private Sprite _upgradeDamage;
    [SerializeField] private Sprite _upgradeRegeneration;
    [SerializeField] private Sprite _upgradeLifesteal;
    [SerializeField] private List<UpgradeButton> _upgradeButtons;

    private Game _game;
    private PauseService _pauseService;
    private EnemyGenerator _enemyGenerator;
    private Gun _gun;
    private PlayerAnimator _playerAnimator;
    private AttackZone _attackZone;
    private PlayerInputRouter _playerInputRouter;

    private void Update()
    {
        _enemyGenerator.Tick(Time.deltaTime); 
        _player.Tick(Time.deltaTime);
        _playerInputRouter.Update();
        _attackZone.Update();
        _playerAnimator.Update();
        _gun.Tick(Time.deltaTime);
    }

    public override void Compose()
    {
        _pauseService = new PauseService();
        _enemyGenerator = new EnemyGenerator(_enemyGeneratorView, _timeToWave, _videoAdvertisement, _progressionSlider);
        
        EndGame endGame = new EndGame();
        UpgradeScreen upgradeScreen = new UpgradeScreen(_pauseService, _player, _upgradeDamage, _upgradeRegeneration, _upgradeLifesteal, _upgradeScreenView, _upgradeButtons);
        ScreenOfGameHelper screenOfGameHelper = new ScreenOfGameHelper(_enemyGenerator, _pauseService, _screenOfGameHelperView);
        AuthorizationError authorizationError = new AuthorizationError(_pauseService, _authorizationErrorView);
        AuthorizationOffer authorizationOffer = new AuthorizationOffer(_authorizationOfferView, _pauseService, authorizationError);

        LeaderboardPresenter leaderboardPresenter = new LeaderboardPresenter(_pauseService, _leaderboardView, _leaderboard);
        AuthorizationOfferPresenter authorizationOfferPresenter = new AuthorizationOfferPresenter(authorizationOffer, _authorizationOfferView);
        AuthorizationErrorPresenter authorizationErrorPresenter = new AuthorizationErrorPresenter(_authorizationErrorView, authorizationError);
        EndGamePresenter endGamePresenter = new EndGamePresenter(_endGameScreen, _pauseService, endGame);
        ScreenOfGameHelperPresentor screenOfGameHelperPresentor = new ScreenOfGameHelperPresentor(screenOfGameHelper, _screenOfGameHelperView);
        UpgradeScreenPresenter upgradeScreenPresenter = new UpgradeScreenPresenter(_upgradeScreenView, upgradeScreen, _upgradeButtons);
        
        _leaderboardView.Init(leaderboardPresenter);
        _authorizationOfferView.Init(authorizationOfferPresenter);
        _authorizationErrorView.Init(authorizationErrorPresenter);
        _endGameScreen.Init(endGamePresenter); 
        _videoAdd.Init(_pauseService);
        _screenOfGameHelperView.Init(screenOfGameHelperPresentor);
        _upgradeScreenView.Init(upgradeScreenPresenter);
        _checkingFocus.Init(_pauseService);
        _leaderboard.Init(authorizationOffer, authorizationError);
        _game = new Game(endGame, upgradeScreen, _enemyGenerator, _addScore, _leaderboardView);

        PlayerPresenter playerPresenter = new PlayerPresenter(_player, _game);
        _player.Init(playerPresenter);
        _playerInputRouter = _player.PlayerInputRouter;
        _attackZone = _player.AttackZone;
        _playerAnimator = _player.PlayerAnimator;
        _gun = _player.Gun;

        _enemyFactory.Init(_template, _player, _hit, _death);
        _enemyGeneratorView.Init(_player, _enemyFactory, _enemyGenerator, _game, _waveCompleted);
    }
}