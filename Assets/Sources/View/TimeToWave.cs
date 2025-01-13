using UnityEngine;
using UnityEngine.UI;

namespace View
{
    [RequireComponent(typeof(Text))]
    public class TimeToWave : MonoBehaviour
    {
        private Text _text;

        private void Awake()
        {
            _text = GetComponent<Text>();
        }

        public void ResetTime(float time)
        {
            if (time <= 0)
                _text.text = string.Empty;
            else
                _text.text = ((int)time).ToString();
        }
    }
}