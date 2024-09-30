using UnityEngine;

public class UpgradeLifesteal : PlayerUpgrade
{
    public UpgradeLifesteal(Sprite image)
    {
        _stat = PlayerStats.Lifesteal;
        _description = "Lifesteal";
        _efficiency = 3;
        _sprite = image;
    }

    public override void Upgrade(Player player)
    {
        player.Upgrade(this);
    }
}