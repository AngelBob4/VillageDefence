using YG.Utils.LB;

namespace View.Yandex.Leaderboard
{
    public struct LeaderboardEntryData
    {
        public LeaderboardEntryData(LBPlayerData entry)
        {
            Rank = entry.rank;
            Name = entry.name;
            Score = entry.score;

            if (string.IsNullOrEmpty(Name))
                Name = Constants.AnonymouseName;
        }

        public int Rank { get; }
        public string Name { get; }
        public int Score { get; }
    }
}