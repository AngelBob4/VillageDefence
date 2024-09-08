using UnityEngine;
using UnityEngine.UI;

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
            _text.text = "";
        else
            _text.text = ((int)time).ToString();
    }
}