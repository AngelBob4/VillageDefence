using Agava.YandexGames;
using UnityEngine;

public class AuthorizationChecker : MonoBehaviour
{
    [SerializeField] private GameObject _AuthorizationButton;

    private void Awake()
    {
        CheckAuthorization();
    }

    public void CheckAuthorization() 
    {
#if !UNITY_EDITOR
        if (PlayerAccount.IsAuthorized)
        {
            _AuthorizationButton.SetActive(false);
        }
#endif
    }
}