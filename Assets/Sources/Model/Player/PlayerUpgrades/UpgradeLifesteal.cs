using UnityEngine;

public class UpgradeLifesteal : PlayerUpgrade
{
    public UpgradeLifesteal(Sprite image)
    {
        _description = "Lifesteal";
        _efficiency = 3;
        _sprite = image;
    }
}