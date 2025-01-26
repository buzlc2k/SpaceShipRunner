using System.Collections.Generic;
using DG.Tweening;

public class Shop_GetFreeCoinButton : BaseAnimatedButton
{

    protected override void OnClick()
    {
        InitializeAnimation();
        Observer.PostEvent(EventID.ButtonGetCoin_Click, new KeyValuePair<EventParameterType, object>(EventParameterType.ButtonGetCoin_Click_Placement, PlacementID.GetCoinButton));
    }

    protected override void InitializeAnimation()
    {
        buttonSquence = DOTween.Sequence();

        buttonSquence.Append(button.transform.DOScale(1.1f, 0.125f))
                    .Append(button.transform.DOScale(1f, 0.125f));
    }
}