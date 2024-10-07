using UnityEngine;
using UnityEngine.UI;
using YG.Utils.LB;
using YG;

public class LeaderboardEntryView : MonoBehaviour
{
    [SerializeField] private Text _rank;
    [SerializeField] private Text _name;
    [SerializeField] private Text _score;
        
    public void Initialize(LBPlayerData entryData)
    {
        _rank.text = entryData.rank.ToString();
        _name.text = entryData.name;
        _score.text = entryData.score.ToString();

        if (string.IsNullOrEmpty(_name.text))
            _name.text = Constants.ANONYMOUS_NAME;
    }

    public void Initialize(LBThisPlayerData entryData)
    {
        _rank.text = entryData.rank.ToString();
        _score.text = entryData.score.ToString();
        _name.text = YandexGame.playerName;

        if (string.IsNullOrEmpty(_name.text))
            _name.text = Constants.ANONYMOUS_NAME;
    }
}