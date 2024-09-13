using UnityEngine;
using UnityEngine.UI;

public class UnitHelathBar : MonoBehaviour
{
    private Slider _slider;
    private Unit _unit;
    private float _maxHealth;
    private Transform _mainCamera;

    public void Init(float maxHealth, Unit unit)
    {
        gameObject.transform.GetChild(0).TryGetComponent(out Slider slider);
        _maxHealth = maxHealth;
        _unit = unit;
        _mainCamera = Camera.main.transform;
        _slider = slider;
        unit.OnHealthChanged += HealthChanged;
    }

    public void HealthChanged()
    {
        float value = _unit.Health / _maxHealth;

        if (_slider != null)
            _slider.value = value;
    }

    private void FixedUpdate()
    {
        transform.rotation = _mainCamera.transform.rotation;
    }
}