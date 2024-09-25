using UnityEngine;
using UnityEngine.UI;

public class AuthorizationErrorView : MonoBehaviour
{
    [SerializeField] private Button _confirmButton;
    [SerializeField] private Game _game;

    private void Awake() => _confirmButton.onClick.AddListener(Hide);
    private void OnDestroy() => _confirmButton.onClick.RemoveListener(Hide);

    private void OnEnable() => _game.Pause(gameObject);

    public void Show() => gameObject.SetActive(true);
    private void Hide() 
    {
        gameObject.SetActive(false);
        _game.Resume(gameObject);
    } 
}