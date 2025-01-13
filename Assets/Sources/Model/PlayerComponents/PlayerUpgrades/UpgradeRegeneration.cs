using UnityEngine;
using View.PlayerComponents;

namespace Model.PlayerComponents.PlayerUpgrades
{
    public class UpgradeRegeneration : PlayerUpgrade
    {
        public UpgradeRegeneration(Sprite sprite)
        {
            Stat = PlayerStats.Regeneration;
            Description = "Regeneration";
            Efficiency = 1;
            Sprite = sprite;
        }

        public override void Upgrade(Player player)
        {
            player.Upgrade(this);
        }
    }
}