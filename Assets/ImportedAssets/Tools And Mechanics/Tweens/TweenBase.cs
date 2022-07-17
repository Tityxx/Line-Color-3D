using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

public class TweenBase : MonoBehaviour
{
    public UnityEvent onStart;
    public UnityEvent onComplete;

    public bool IsCompleted { get; protected set; }

    [SerializeField]
    protected float duration;
    [SerializeField]
    protected Ease easeType = Ease.Linear;
    [SerializeField]
    protected bool canBeInterrupted = true;
    [SerializeField]
    protected bool executeOnEnable;
    [SerializeField]
    protected bool overrideValueOnStart = true;
    [SerializeField]
    protected LoopType loopType;
    [SerializeField]
    [Tooltip("-1 equals endless")]
    protected int loopCount = 1;

    protected Tween curTween;

    protected virtual void OnEnable()
    {
        if (executeOnEnable)
        {
            Execute();
        }
    }

    public virtual void Execute(bool straight = true)
    {
        Stop();

        IsCompleted = false;
        onStart.Invoke();
    }

    public virtual void Stop()
    {
        if(curTween != null)
        {
            curTween.Rewind();
        }
    }

    public virtual void Kill()
    {
        if(curTween != null)
        {
            curTween.Kill();
        }
    }

    public virtual void Pause()
    {
        if (curTween != null)
        {
            curTween.Pause();
        }
    }

    public virtual void OnCompleted()
    {
        curTween = null;
        IsCompleted = true;
        onComplete.Invoke();
    }

    [ContextMenu("Execute")]
    private void MenuExecute()
    {
        Execute();
    }

    [ContextMenu("Reverse Execute")]
    private void MenuReverseExecute()
    {
        Execute(false);
    }
}
