using UnityEngine;

public abstract class PlayerUpgrade
{
    protected string _description;
    protected int _efficiency;
    protected Sprite _sprite;
    protected PlayerStats _stat;

    public PlayerStats Stat => _stat;
    public string Description => _description;
    public int Efficiency => _efficiency;
    public Sprite Sprite => _sprite;

    public abstract void Upgrade(Player player);
}