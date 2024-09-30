using Agava.YandexGames;
using UnityEngine;
using UnityEngine.UI;

public class AuthorizationChecker : MonoBehaviour
{
    [SerializeField] private GameObject _AuthorizationButton;
    [SerializeField] private Text _name;

    private void Awake()
    {
        Check();
    }

    public void Check()
    {
#if !UNITY_EDITOR
        if (PlayerAccount.IsAuthorized)
        {
            _AuthorizationButton.SetActive(false);

            PlayerAccount.GetProfileData((result) =>
            {
                string name = result.publicName;

                if (string.IsNullOrEmpty(name))
                    name = "Anonymous";

                _name.text = name;
            });
        }
#endif
    }
}