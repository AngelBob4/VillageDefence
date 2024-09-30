using UnityEngine;
using UnityEngine.UI;

public class ProgressionSlider : MonoBehaviour
{
    [SerializeField] private Slider _progressSlider;
    [SerializeField] private Text _leftLevel;
    [SerializeField] private Text _rightLevel;
    
    private float _smoothSpeed = 0.125f;
    private float _newValue = 0;

    public void ResetValues(float killed—ount, float maxEnemies, int waveCounter)
    {
        _newValue = killed—ount / maxEnemies;
        _leftLevel.text = waveCounter.ToString();
        _rightLevel.text = (waveCounter + 1).ToString();
    }

    private void FixedUpdate()
    {
        _progressSlider.value = Mathf.Lerp(_progressSlider.value, _newValue, _smoothSpeed);
    }
}