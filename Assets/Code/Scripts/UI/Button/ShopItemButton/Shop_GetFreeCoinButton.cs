using System.Collections.Generic;
using DG.Tweening;

public class Shop_GetFreeCoinButton : BaseAnimatedButton
{

    protected override void OnClick()
    {
        InitializeAnimation();
        Observer.PostEvent(EventID.WantToWatch_ADS, new KeyValuePair<EventParameterType, object>(EventParameterType.WantToWatch_ADS_PlacementID, PlacementID.GetCoinButton));
    }

    protected override void InitializeAnimation()
    {
        buttonSquence = DOTween.Sequence();

        buttonSquence.Append(button.transform.DOScale(1.1f, 0.125f))
                    .Append(button.transform.DOScale(1f, 0.125f));
    }
}