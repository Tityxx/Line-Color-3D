using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdShower : MonoBehaviour
{
    private static YandexSDK sdk => YandexSDK.instance;

    private static bool isInited;
    private static float lastInterstitialTime;

    private const float MINIMUM_INTERSTITIAL_DELAY = 30f;
    private const string REWARD_KEY = "Reward";

    private void Start()
    {
        if (isInited)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            isInited = true;
            DontDestroyOnLoad(gameObject);
        }

        lastInterstitialTime = Time.time;
    }

    public static void ShowAd()
    {
        if (lastInterstitialTime + MINIMUM_INTERSTITIAL_DELAY > Time.time) return;

        lastInterstitialTime = Time.time;

        if (Application.isEditor)
        {
            Debug.Log("SHOW AD!");
        }
        else
        {
            sdk.ShowInterstitial();
        }
    }
    public static void ShowRewardAd()
    {
        if (Application.isEditor)
        {
            Debug.Log("SHOW REWARD!");
        }
        else
        {
            sdk.ShowRewarded(REWARD_KEY);
        }
    }
}