using UnityEngine;
using UnityEngine.UI;

namespace LeaderboardDemo
{
    internal class AddScore : MonoBehaviour
    {
        [SerializeField] private Text _score;

        private void Awake()
        {
            Agava.YandexGames.PlayerAccount.AuthorizedInBackground += OnAuthorized;
            UpdateScoreView();
        }
        
        private void OnDestroy()
        {
            Agava.YandexGames.PlayerAccount.AuthorizedInBackground -= OnAuthorized;
        }

        public void UpdateScoreView() => 
            _score.text = Agava.YandexGames.Utility.PlayerPrefs.GetInt(Constants.SCORE_PREFS_KEY, 0).ToString();
        
        private void OnAuthorized() => UpdateScoreView();
    }
}