using UnityEngine;
using UnityEngine.UI;

public class AddScore : MonoBehaviour
{
    [SerializeField] private Text _score;

    private void Awake()
    {
#if !UNITY_EDITOR
        Agava.YandexGames.PlayerAccount.AuthorizedInBackground += OnAuthorized;
        UpdateScoreView();
#endif
    }
        
    private void OnDestroy()
    {
        Agava.YandexGames.PlayerAccount.AuthorizedInBackground -= OnAuthorized;
    }

    public void UpdateScoreView() => 
        _score.text = Agava.YandexGames.Utility.PlayerPrefs.GetInt(Constants.SCORE_PREFS_KEY, 0).ToString();

    public void UpdateScoreView(int score) =>
        _score.text = score.ToString();

    private void OnAuthorized() => UpdateScoreView();
}