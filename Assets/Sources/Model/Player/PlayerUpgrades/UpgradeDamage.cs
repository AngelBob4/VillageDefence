using UnityEngine.UI;

public class UpgradeDamage : PlayerUpgrade
{
    public UpgradeDamage(Image image)
    {
        _description = "Increase damage";
        _percentsOfEfficiency = "15%";
        _image = image;
    }

    public override void Upgrade(Player player)
    {
        player.UpgradePlayer();
    }
}