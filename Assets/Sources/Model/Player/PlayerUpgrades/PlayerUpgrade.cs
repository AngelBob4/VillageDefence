using UnityEngine;
using UnityEngine.UI;

public abstract class PlayerUpgrade : MonoBehaviour
{
    protected string _description;
    protected string _percentsOfEfficiency;

    public string Description => _description;
    public string PercentsOfEfficiency => _percentsOfEfficiency;

    public abstract void Upgrade(Player player);
}