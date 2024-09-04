using Agava.YandexGames;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SDKInitializer : MonoBehaviour
{
    private void Awake()
    {
        YandexGamesSdk.CallbackLogging = true;
    }
}
