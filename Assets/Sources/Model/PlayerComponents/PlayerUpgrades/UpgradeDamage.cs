using UnityEngine;
using View.PlayerComponents;

namespace Model.PlayerComponents.PlayerUpgrades
{
    public class UpgradeDamage : PlayerUpgrade
    {
        public UpgradeDamage(Sprite image)
        {
            Stat = PlayerStats.Damage;
            Description = "Increase damage";
            Efficiency = 15;
            Sprite = image;
        }

        public override void Upgrade(Player player)
        {
            player.Upgrade(this);
        }
    }
}