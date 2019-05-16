using System;
using System.Collections;

public class MyTween
{
    public bool IsComplete;//整个淡入淡出动画是否完成
    Action HalfAction;//淡入做完后的事件绑定
    Action CompleteAction;//整个动画做完后的事件绑定

    public MyTween()
    {
        IsComplete = false;
        HalfAction = null;
        CompleteAction = null;
    }

    public void OnHalfComplete(Action action)
    {
        this.HalfAction = action;
    }

    public void OnComplete(Action action)
    {
        this.CompleteAction = action;
    }

    //执行到一半的时候执行的事件
    public void HalfCompleteExcute()
    {
        if (HalfAction != null) HalfAction();
    }

    //结束后执行的事件
    public void CompleteExcute()
    {
        if (CompleteAction != null) CompleteAction();
    }
}
