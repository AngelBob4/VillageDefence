using System;

namespace Model
{
    public class EndGame
    {
        public event Action<float, int, int> ScreenOpenedWithDelay;

        public void Open(float openingDelay, int score, int wavesComplited)
        {
            ScreenOpenedWithDelay?.Invoke(openingDelay, score, wavesComplited);
        }
    }
}