using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class GameResult_DoubleCoinButton : BaseButton
{
    protected override void OnClick()
    {
        Observer.PostEvent(EventID.ButtonDoubleCoin_Click, new KeyValuePair<EventParameterType, object>(EventParameterType.ButtonDoubleCoin_Click_Placement, PlacementID.DoubleCoinButton));
        ((GameResultCanvas)GetCanvas()).SetOnlyReloadGameButton();
    }
}