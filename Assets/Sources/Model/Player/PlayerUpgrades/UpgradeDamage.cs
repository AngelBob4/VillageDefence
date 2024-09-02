using UnityEngine;

public class UpgradeDamage : PlayerUpgrade
{
    public UpgradeDamage(Sprite image)
    {
        _description = "Increase damage";
        _efficiency = 15;
        _sprite = image;
    }
}