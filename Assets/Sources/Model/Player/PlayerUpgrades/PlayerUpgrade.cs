using UnityEngine;

public abstract class PlayerUpgrade
{
    protected string _description;
    protected int _efficiency;
    protected Sprite _sprite;

    public string Description => _description;
    public int Efficiency => _efficiency;
    public Sprite Sprite => _sprite;

    public void Upgrade(Player player)
    {
        player.UpgradePlayer(this);
    }
}