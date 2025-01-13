using Lean.Localization;
using UnityEngine;
using UnityEngine.UI;
using YG;
using YG.Utils.LB;

namespace View.Yandex
{
    public class AuthorizationChecker : MonoBehaviour
    {
        [SerializeField] private GameObject _AuthorizationButton;
        [SerializeField] private Text _name;
        [SerializeField] private LeanLocalizedText _leanLocalizedText;

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
                {
                    _leanLocalizedText.enabled = true;
                }
                else
                {
                    _leanLocalizedText.enabled = false;
                    _name.text = name;
                }
            }
        }
    }
}