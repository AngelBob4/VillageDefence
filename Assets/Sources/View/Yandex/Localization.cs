using Lean.Localization;
using UnityEngine;
using YG;

namespace View.Yandex
{
    public class Localization : MonoBehaviour
    {
        private const string EnglishCode = "English";
        private const string RussianCode = "Russian";
        private const string TurkishCode = "Turkish";
        private const string Russian = "ru";
        private const string Turkish = "tr";

        public void Start()
        {
#if !UNITY_EDITOR
        string languageCode = YandexGame.lang;
#else
            string languageCode = Russian;
#endif
            switch (languageCode)
            {
                case Russian:
                    LeanLocalization.SetCurrentLanguageAll(RussianCode);
                    break;
                case Turkish:
                    LeanLocalization.SetCurrentLanguageAll(TurkishCode);
                    break;
                default:
                    LeanLocalization.SetCurrentLanguageAll(EnglishCode);
                    break;
            }
        }
    }
}