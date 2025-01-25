using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class GameOver_ReviveButton : BaseAnimatedButton
{
    protected override void OnEnable()
    {
        base.OnEnable();

        InitializeAnimation();
    }

    protected override void InitializeAnimation()
    {
        buttonSquence = DOTween.Sequence();

        buttonSquence.AppendInterval(1);

        for (int i = 0; i < 2; i++)
        {
            buttonSquence
                .Append(button.transform.DORotate(new Vector3(0, 0, 2), 0.1f))
                .Append(button.transform.DORotate(new Vector3(0, 0, -2), 0.1f));
        }

        buttonSquence.SetLoops(-1, LoopType.Yoyo);
    }

    protected override void OnClick()
    {
        Observer.PostEvent(EventID.ButtonRiveve_Click, new KeyValuePair<EventParameterType, object>(EventParameterType.ButtonRiveve_Click_Placement, PlacementID.ReviveButton));
    }
}