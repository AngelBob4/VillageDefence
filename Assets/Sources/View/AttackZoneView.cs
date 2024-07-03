using UnityEngine;

public class AttackZoneView : MonoBehaviour
{
    private AttackZone _attackZone;

    public void Init(AttackZone attackZone)
    {
        _attackZone = attackZone;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Enemy enemy))
        {
            _attackZone.TrySetTarget(enemy);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent(out Enemy enemy))
        {
            _attackZone.TrySetTarget(enemy);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Enemy enemy))
        {
            _attackZone.ResetTarget();
        }
    }
}