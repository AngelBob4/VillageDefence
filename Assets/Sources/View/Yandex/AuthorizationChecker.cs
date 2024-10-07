using YG;
using UnityEngine;
using UnityEngine.UI;
using YG.Utils.LB;

public class AuthorizationChecker : MonoBehaviour
{
    [SerializeField] private GameObject _AuthorizationButton;
    [SerializeField] private Text _name;

    private void Awake()
    {
        YandexGame.onGetLeaderboard += Check;
    }

    private void OnDestroy()
    {
        YandexGame.onGetLeaderboard -= Check;
    }

    public void Check(LBData data)
    {
        if (YandexGame.auth)
        {
            _AuthorizationButton.SetActive(false);

            string name = YandexGame.playerName;

            if (string.IsNullOrEmpty(name))
                name = Constants.ANONYMOUS_NAME;

            _name.text = name;
        }
    }
}