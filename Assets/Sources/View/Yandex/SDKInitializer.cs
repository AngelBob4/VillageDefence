using Agava.YandexGames;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Localization))]
public class SDKInitializer : MonoBehaviour
{
    private Localization _localization;

    private void Awake()
    {
        YandexGamesSdk.CallbackLogging = true;
        _localization = GetComponent<Localization>();
    }

    private IEnumerator Start()
    {
        yield return YandexGamesSdk.Initialize(OnInitialized);
    }

    private void OnInitialized()
    {
#if !UNITY_EDITOR
        Agava.YandexGames.Utility.PlayerPrefs.SetInt(Constants.FIRST_OPEN_KEY, Constants.TRUE_VALUE);
        Agava.YandexGames.Utility.PlayerPrefs.Save();
        _localization.ChangeLanguage();
#endif
        SceneManager.LoadScene(1);
    }
}