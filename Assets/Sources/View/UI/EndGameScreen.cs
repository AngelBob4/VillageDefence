using System;
using UnityEngine.UI;
using UnityEngine;
using DG.Tweening;
using YG;

public class EndGameScreen : MonoBehaviour
{
    [SerializeField] private Button _rewardConfirmationConfirmButton;
    [SerializeField] private Button _rewardConfirmationRejectButton;
    [SerializeField] private GameObject _rewardConfirmation;

    [SerializeField] private Button _rewardAdvertisementButton;
    [SerializeField] private GameObject _rewardAdvertisement;
    [SerializeField] private GameObject _advertisementLoadingPanel;
    [SerializeField] private Player _player;

    [SerializeField] private CanvasGroup _windowGroup;
    [SerializeField] private Button _restartGameButton;
    [SerializeField] private RectTransform _panel;
    [SerializeField] private Text _score;
    [SerializeField] private Text _waveComplited;

    private bool _rewardReceived = false;
    private IPresenter _presenter;

    public event Action RestartButtonClicked;
    public event Action ScreenOpened;

    public void Init(IPresenter presenter)
    {
        gameObject.SetActive(false);
        _presenter = presenter;
        gameObject.SetActive(true);
    }

    private void OnEnable()
    {
        YandexGame.RewardVideoEvent += Rewarded;
        YandexGame.CloseVideoEvent += CloseRewardVideo;
        _presenter?.Enable();
        _restartGameButton.onClick.AddListener(OnButtonClick);
        _rewardAdvertisementButton.onClick.AddListener(OpenRewardConfirmation);
        _rewardConfirmationConfirmButton.onClick.AddListener(StartRewardVideo);
        _rewardConfirmationRejectButton.onClick.AddListener(CloseRewardConfirmation);
    }

    private void OnDisable()
    {
        YandexGame.RewardVideoEvent -= Rewarded;
        YandexGame.CloseVideoEvent -= CloseRewardVideo;
        _presenter?.Disable();
        _restartGameButton.onClick.RemoveListener(OnButtonClick);
        _rewardAdvertisementButton.onClick.RemoveListener(OpenRewardConfirmation);
        _rewardConfirmationConfirmButton.onClick.RemoveListener(StartRewardVideo);
        _rewardConfirmationRejectButton.onClick.RemoveListener(CloseRewardConfirmation);
    }

    private void OnButtonClick()
    {
        RestartButtonClicked?.Invoke();
    }

    private void OpenRewardConfirmation()
    {
        Close();
        _rewardConfirmation.SetActive(true);
    }

    private void CloseRewardConfirmation()
    {
        _windowGroup.alpha = 1f;
        _windowGroup.blocksRaycasts = true;
        _rewardConfirmation.SetActive(false);
    }

    public void Open(float delay, int score, int waves)
    {
        if (_rewardReceived)
        {
            _rewardAdvertisement.SetActive(false);
        }

        _score.text = score.ToString();
        _waveComplited.text = (waves - 1).ToString();

        _windowGroup.alpha = 1f;
        _panel.localScale = Vector3.zero;
        _panel.DOScale(1, delay).SetUpdate(true).SetLink(_panel.gameObject).OnComplete(CompleteScreenOpening);
    }

    private void CompleteScreenOpening()
    {
        _windowGroup.blocksRaycasts = true;
        ScreenOpened?.Invoke();
    }

    private void StartRewardVideo()
    {
        _advertisementLoadingPanel.SetActive(true);
        YandexGame.RewVideoShow(0);
    }

    private void Rewarded(int id)
    {
        _rewardReceived = true;
        _player.Revive(); 
        Close();
        _advertisementLoadingPanel.SetActive(false);
        _rewardConfirmation.SetActive(false);
    }

    private void Close()
    {
        _windowGroup.alpha = 0f;
        _windowGroup.blocksRaycasts = false;
    }

    private void CloseRewardVideo()
    {
        if (_rewardReceived)
            return;

        _windowGroup.blocksRaycasts = true;
        _windowGroup.alpha = 1f;
        _advertisementLoadingPanel.SetActive(false);
        _rewardConfirmation.SetActive(false);
    }
}