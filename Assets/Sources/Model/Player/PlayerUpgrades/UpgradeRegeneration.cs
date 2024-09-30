using UnityEngine;

public class UpgradeRegeneration : PlayerUpgrade
{
    public UpgradeRegeneration(Sprite sprite)
    {
        _stat = PlayerStats.Regeneration;
        _description = "Regeneration";
        _efficiency = 1;
        _sprite = sprite;
    }

    public override void Upgrade(Player player)
    {
        player.Upgrade(this);
    }
}