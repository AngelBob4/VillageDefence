using UnityEngine;
using UnityEngine.UI;

namespace LeaderboardDemo
{
    internal class LeaderboardEntryView : MonoBehaviour
    {
        [SerializeField] private Text _rank;
        [SerializeField] private Text _name;
        [SerializeField] private Text _score;
        
        public void Initialize(LeaderboardEntryData entryData)
        {
            _rank.text = entryData.Rank.ToString();
            _name.text = entryData.Name;
            _score.text = entryData.Score.ToString();
        }
    }
}