using UnityEngine;
using YG;
using YG.Utils.LB;

public struct LeaderboardEntryData
{
    public LeaderboardEntryData(LBPlayerData entry)
    {
        Rank = entry.rank;
        Name = entry.name;
        Score = entry.score;
            
        if (string.IsNullOrEmpty(Name))
            Name = Constants.ANONYMOUS_NAME;
    }
        
    public int Rank { get; }
    public string Name { get; }
    public int Score { get; }
}