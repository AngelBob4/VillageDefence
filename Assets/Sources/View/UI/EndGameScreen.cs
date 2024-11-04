using System;
using UnityEngine.UI;
using UnityEngine;
using DG.Tweening;

public class EndGameScreen : MonoBehaviour
{
    [SerializeField] private CanvasGroup _windowGroup;
    [SerializeField] private Button _actionButton;
    [SerializeField] private RectTransform _panel;
    [SerializeField] private Text _score;
    [SerializeField] private Text _waveComplited;

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
        _presenter?.Enable();
        _actionButton.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        _presenter?.Disable();
        _actionButton.onClick.RemoveListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        RestartButtonClicked?.Invoke();
    }

    public void Open(float delay, int score, int waves)
    {
        _score.text = score.ToString();
        _waveComplited.text = (waves - 1).ToString();

        _windowGroup.alpha = 1f;
        _panel.localScale = Vector3.zero;
        _panel.DOScale(1, delay).SetLink(_panel.gameObject).OnComplete(CompleteScreenOpening);
    }

    private void CompleteScreenOpening()
    {
        _windowGroup.blocksRaycasts = true;
        ScreenOpened?.Invoke();
    }

    public void Close()
    {
        _windowGroup.alpha = 0f;
        _windowGroup.blocksRaycasts = false;
    }
}