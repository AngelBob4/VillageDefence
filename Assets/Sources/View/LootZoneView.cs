using UnityEngine;

public class LootZoneView : MonoBehaviour
{
    private Inventory _inventory;

    public void Init(Inventory inventory)
    {
        _inventory = inventory;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Bullet bullet))
        {
            _inventory.AddBullet(bullet);
        }
    }
}