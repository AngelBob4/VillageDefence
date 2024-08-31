using UnityEngine.UI;

public abstract class PlayerUpgrade
{
    protected string _description;
    protected string _percentsOfEfficiency;
    protected Image _image;

    public string Description => _description;
    public string PercentsOfEfficiency => _percentsOfEfficiency;
    public Image Image => _image;

    public abstract void Upgrade(Player player);
}