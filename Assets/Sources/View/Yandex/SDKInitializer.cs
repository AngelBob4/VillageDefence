using YG;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SDKInitializer : MonoBehaviour
{
    private void Awake()
    {
        YandexGame.GetDataEvent += OnInitialized;
    }

    private void OnInitialized()
    {
        YandexGame.savesData.isFirstSession = true;
        YandexGame.SaveProgress();
        SceneManager.LoadScene(1);
    }
}