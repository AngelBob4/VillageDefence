using Agava.YandexGames;
using System;
using System.Collections;
using UnityEngine;

public class CheckAuthorization : MonoBehaviour
{
    public void OnAuthorizeButtonClick()
    {
        PlayerAccount.Authorize();
    }

    public void OnGetProfileDataButtonClick()
    {
        PlayerAccount.GetProfileData((result) =>
        {
            string name = result.publicName;
            if (string.IsNullOrEmpty(name))
                name = "Anonymous";
            Debug.Log($"My id = {result.uniqueID}, name = {name}");
        });
    }

    private void Awake()
    {
        YandexGamesSdk.CallbackLogging = true;
        PlayerAccount.AuthorizedInBackground += OnAuthorizedInBackground;
    }

    private void OnDestroy()
    {
        PlayerAccount.AuthorizedInBackground -= OnAuthorizedInBackground;
    }

    private void OnAuthorizedInBackground()
    {
        Debug.Log($"{nameof(OnAuthorizedInBackground)} {PlayerAccount.IsAuthorized}");
    }
}