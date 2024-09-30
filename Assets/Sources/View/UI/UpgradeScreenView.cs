using UnityEngine;
using DG.Tweening;

public class UpgradeScreenView : MonoBehaviour
{
    [SerializeField] private RectTransform _panel;
    [SerializeField] private CanvasGroup _windowGroup;

    private IPresenter _presenter;

    public void Init(IPresenter presenter)
    {
        gameObject.SetActive(false);
        _presenter = presenter;
        gameObject.SetActive(true);
    }

    private void OnEnable()
    {
        _presenter.Enable();
    }

    private void OnDisable()
    {
        _presenter.Disable();
    }

    public void Open(float openingDelay)
    {
        _windowGroup.alpha = 1f;
        _panel.localScale = Vector3.zero;
        _panel.DOScale(1, openingDelay).OnComplete(TurnOnRaycasts);
    }

    private void TurnOnRaycasts()
    {
        _windowGroup.blocksRaycasts = true;
    }

    public void Close()
    {
        _windowGroup.alpha = 0f;
        _windowGroup.blocksRaycasts = false;
    }
}