using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using System.Collections;

public class playfabthinga : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(CheckBanLoop());
    }

    IEnumerator CheckBanLoop()
    {
        while (true)
        {
            CheckBan();
            yield return new WaitForSeconds(10f);
        }
    }

    void CheckBan()
    {
        PlayFabClientAPI.GetAccountInfo(
            new GetAccountInfoRequest(),
            result =>
            {
             //Tung Tung Tung // Not fucking banned
            },
            error =>
            {
                if (error.Error == PlayFabErrorCode.AccountBanned)
                {
                    Application.Quit();
                }
            }
        );
    }
}
