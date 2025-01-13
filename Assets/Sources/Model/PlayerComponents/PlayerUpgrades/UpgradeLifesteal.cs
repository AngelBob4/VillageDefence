using UnityEngine;
using View.PlayerComponents;

namespace Model.PlayerComponents.PlayerUpgrades
{
    public class UpgradeLifesteal : PlayerUpgrade
    {
        public UpgradeLifesteal(Sprite image)
        {
            Stat = PlayerStats.Lifesteal;
            Description = "Lifesteal";
            Efficiency = 3;
            Sprite = image;
        }

        public override void Upgrade(Player player)
        {
            player.Upgrade(this);
        }
    }
}