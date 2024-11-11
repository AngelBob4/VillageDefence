using UnityEngine;
using UnityEngine.UI;
using YG;
using YG.Utils.LB;

public class AddScore : MonoBehaviour
{
    [SerializeField] private Text _score;

    private void Awake()
    {
        YandexGame.onGetLeaderboard += OnAuthorized;
    }

    private void OnDestroy()
    {
        YandexGame.onGetLeaderboard -= OnAuthorized;
    }

    public void UpdateScoreView() => 
        _score.text = YandexGame.savesData.score.ToString();

    public void UpdateScoreView(int score) =>
        _score.text = score.ToString();

    private void OnAuthorized(LBData data) => UpdateScoreView();
}