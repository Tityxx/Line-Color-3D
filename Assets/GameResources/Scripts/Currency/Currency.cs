using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public enum CurrencyType
{
    Coins,
    Crystals
}

public static class Currency
{
    public static event Action<CurrencyType> onValueChange = delegate { };
    public static event Action<CurrencyType> onNotEnoughMoney = delegate { };

    public static int GetValue(CurrencyType type)
    {
        return PlayerPrefs.GetInt(GetKey(CurrencyType.Coins), 0);
    }

    public static void SetValue(CurrencyType type, int value)
    {
        if (value != GetValue(type))
        {
            PlayerPrefs.SetInt(GetKey(type), Mathf.Clamp(value, 0, int.MaxValue));
            PlayerPrefs.Save();
            onValueChange(CurrencyType.Coins);
        }
    }

    public static void NotEnoughMoney(CurrencyType type)
    {
        onNotEnoughMoney(type);
    }

    private static string GetKey(CurrencyType type)
    {
        return string.Format(SAVE_KEY, type.ToString());
    }

    private const string SAVE_KEY = "Currency {0} value";
}
