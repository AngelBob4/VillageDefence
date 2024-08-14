using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup))]
public abstract class Window : MonoBehaviour
{
    private Button _actionButton;
    private CanvasGroup _windowGroup;

    protected CanvasGroup WindowGroup => _windowGroup;
    protected Button ActionButton => _actionButton;

    public void Init(Button button)
    {
        _actionButton = button;
        _actionButton.onClick.AddListener(OnButtonClick);
        _windowGroup = GetComponent<CanvasGroup>();
        Close();
    }

    public void Open()
    {
        WindowGroup.alpha = 1f;
        WindowGroup.blocksRaycasts = true;
        ActionButton.interactable = true;
    }

    public void Close()
    {
        WindowGroup.alpha = 0f;
        WindowGroup.blocksRaycasts = false;
        ActionButton.interactable = false;
    }

    private void OnDisable()
    {
        _actionButton.onClick.RemoveListener(OnButtonClick);
    }

    protected abstract void OnButtonClick();
}