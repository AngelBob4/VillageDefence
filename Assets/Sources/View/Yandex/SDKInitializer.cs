using UnityEngine;
using UnityEngine.SceneManagement;
using YG;

namespace View.Yandex
{
    public class SDKInitializer : MonoBehaviour
    {
        private void Awake()
        {
            YandexGame.GetDataEvent += OnInitialized;
        }

        private void OnDestroy()
        {
            YandexGame.GetDataEvent -= OnInitialized;
        }

        private void OnInitialized()
        {
            int firstSceneIndex = 1;
            
            YandexGame.savesData.isFirstSession = true;
            YandexGame.SaveProgress();
            SceneManager.LoadScene(firstSceneIndex);
        }
    }
}