using Agava.YandexGames;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SDKInitializer : MonoBehaviour
{
    private void Awake()
    {
        YandexGamesSdk.CallbackLogging = true;
    }

    private IEnumerator Start()
    {
#if !UNITY_EDITOR
        yield return YandexGamesSdk.Initialize(OnInitialized);
#else
        OnInitialized();
        yield break;
#endif
    }

    private void OnInitialized()
    {
#if !UNITY_EDITOR
        if (Agava.YandexGames.Utility.PlayerPrefs.HasKey(Constants.FIRST_OPEN_KEY) == false)
        {
            Agava.YandexGames.Utility.PlayerPrefs.SetInt(Constants.FIRST_OPEN_KEY, Constants.TRUE_VALUE);
            Agava.YandexGames.Utility.PlayerPrefs.Save();
        }
#endif
        SceneManager.LoadScene(1);
    }
}