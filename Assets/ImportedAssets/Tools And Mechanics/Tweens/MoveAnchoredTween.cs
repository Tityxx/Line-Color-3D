using DG.Tweening;
using UnityEngine;

public class MoveAnchoredTween : TweenBase
{
    [Space]
    [SerializeField]
    private Vector2 startPosition;
    [SerializeField]
    private Vector2 endPosition;

    private RectTransform rect => transform as RectTransform;

    private void Awake()
    {
        if (overrideValueOnStart)
        {
            ResetPosition();
        }
    }

    public override void Execute(bool straight = true)
    {
        if (curTween != null)
        {
            if (curTween.IsPlaying() && !canBeInterrupted) return;
        }

        base.Execute(straight);

        if (overrideValueOnStart)
        {
            ResetPosition(straight);
        }

        if (straight)
        {
            curTween = rect.DOAnchorPos(endPosition, duration).
                SetEase(easeType).
                SetLoops(loopCount, loopType).
                OnComplete(() => OnCompleted());
        }
        else
        {
            curTween = rect.DOAnchorPos(startPosition, duration).
                SetEase(easeType).
                SetLoops(loopCount, loopType).
                OnComplete(() => OnCompleted());
        }
    }

    private void ResetPosition(bool straight = true)
    {
        if (straight)
        {
            rect.anchoredPosition = startPosition;
        }
        else
        {
            rect.anchoredPosition = endPosition;
        }
    }
}
