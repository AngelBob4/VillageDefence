using UnityEngine;
using UnityEngine.UI;
using YG.Utils.LB;
using YG;
using Lean.Localization;

public class LeaderboardEntryView : MonoBehaviour
{
    [SerializeField] private Text _rank;
    [SerializeField] private Text _name;
    [SerializeField] private Text _score;

    [SerializeField] private LeanLocalizedText _localization;
        
    public void Initialize(LBPlayerData entryData)
    {
        _rank.text = entryData.rank.ToString();
        _score.text = entryData.score.ToString();

        if (string.IsNullOrEmpty(entryData.name))
        {
            _localization.enabled = true;
        }
        else
        {
            _localization.enabled = false;
            _name.text = entryData.name;
        }
    }

    public void Initialize(LBThisPlayerData entryData)
    {
        _rank.text = entryData.rank.ToString();
        _score.text = entryData.score.ToString();

        if (string.IsNullOrEmpty(YandexGame.playerName))
        {
            _localization.enabled = true;
        }
        else
        {
            _localization.enabled = false;
            _name.text = YandexGame.playerName;
        }
    }
}