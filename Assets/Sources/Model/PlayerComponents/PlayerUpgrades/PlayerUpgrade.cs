using UnityEngine;
using View.PlayerComponents;

namespace Model.PlayerComponents.PlayerUpgrades
{
    public abstract class PlayerUpgrade
    {
        public PlayerStats Stat { get; protected set; }
        public string Description { get; protected set; }
        public int Efficiency { get; protected set; }
        public Sprite Sprite { get; protected set; }

        public abstract void Upgrade(Player player);
    }
}