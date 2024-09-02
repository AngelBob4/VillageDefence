using UnityEngine;

public class UpgradeRegeneration : PlayerUpgrade
{
    public UpgradeRegeneration(Sprite sprite)
    {
        _description = "Regeneration";
        _efficiency = 1;
        _sprite = sprite;
    }
}