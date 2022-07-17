using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(TMP_Text))]
public class CurrencyView : MonoBehaviour
{
    [SerializeField]
    private CurrencyType type;
    [SerializeField]
    private float durationOnChange = 0.3f;
    [SerializeField]
    private float scaleOnChange = 1.2f;

    private Tween tween;

    private TMP_Text text;

    private void Awake()
    {
        text = GetComponent<TMP_Text>();
    }

    private void OnEnable()
    {
        text.text = Currency.GetValue(type).ToString();
        Currency.onValueChange += OnValueChange;
        Currency.onNotEnoughMoney += OnNotEnoughMoney;
    }

    private void OnDisable()
    {
        Currency.onValueChange -= OnValueChange;
        Currency.onNotEnoughMoney -= OnNotEnoughMoney;
    }

    private void OnValueChange(CurrencyType type)
    {
        if (this.type != type) return;

        text.text = Currency.GetValue(type).ToString();
        
        if (tween != null && tween.IsPlaying()) return;

        tween = transform.DOScale(Vector3.one * scaleOnChange, durationOnChange / 2).SetEase(Ease.InOutBounce).OnComplete(() => 
        {
            tween = transform.DOScale(Vector3.one, durationOnChange / 2).SetEase(Ease.InOutBounce); 
        });
    }

    private void OnNotEnoughMoney(CurrencyType type)
    {
        if (this.type != type) return;

        text.color = Color.red;

        if (tween != null && tween.IsPlaying()) return;

        tween = transform.DOScale(Vector3.one * scaleOnChange, durationOnChange / 2).SetEase(Ease.InOutBounce).OnComplete(() =>
        {
            tween = transform.DOScale(Vector3.one, durationOnChange / 2).SetEase(Ease.InOutBounce).OnComplete(() => {
                text.color = Color.white;
            });
        });
    }
}
