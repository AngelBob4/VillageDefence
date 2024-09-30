using Agava.YandexGames;
using Lean.Localization;
using UnityEngine;

public class Localization : MonoBehaviour
{
    private const string EnglishCode = "English";
    private const string RussianCode = "Russian";
    private const string TurkishCode = "Turkish";
    private const string English = "en";
    private const string Russian = "ru";
    private const string Turkish = "tr";

    public void Start()
    {
#if !UNITY_EDITOR
        string languageCode = YandexGamesSdk.Environment.i18n.lang;
#else
        string languageCode = Turkish;
#endif
        switch (languageCode)
        {
            case Russian:
                Lean.Localization.LeanLocalization.SetCurrentLanguageAll(RussianCode);
                break;
            case Turkish:
                Lean.Localization.LeanLocalization.SetCurrentLanguageAll(TurkishCode);
                break;
            default:
                Lean.Localization.LeanLocalization.SetCurrentLanguageAll(EnglishCode);
                break;
        }
    }
}