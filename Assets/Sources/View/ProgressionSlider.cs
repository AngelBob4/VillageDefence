using UnityEngine;
using UnityEngine.UI;

namespace View
{
    public class ProgressionSlider : MonoBehaviour
    {
        [SerializeField] private Slider _progressSlider;
        [SerializeField] private Text _leftLevel;
        [SerializeField] private Text _rightLevel;

        private float _smoothSpeed = 0.125f;
        private float _newValue = 0;

        public void ResetValues(float killedCount, float maxEnemies, int waveCounter)
        {
            string leftLevelText = waveCounter.ToString();
            string rightLevelText = (waveCounter + 1).ToString();

            _newValue = killedCount / maxEnemies;
            _leftLevel.text = leftLevelText;
            _rightLevel.text = rightLevelText;
        }

        private void FixedUpdate()
        {
            _progressSlider.value = Mathf.Lerp(_progressSlider.value, _newValue, _smoothSpeed);
        }
    }
}