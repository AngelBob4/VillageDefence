using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public abstract class Window : MonoBehaviour
{
    [SerializeField] private CanvasGroup _windowGroup;

    protected CanvasGroup WindowGroup => _windowGroup;

    public virtual void Open()
    {
        WindowGroup.alpha = 1f;
        WindowGroup.blocksRaycasts = true;
    }

    public virtual void Close()
    {
        WindowGroup.alpha = 0f;
        WindowGroup.blocksRaycasts = false;
    }
}