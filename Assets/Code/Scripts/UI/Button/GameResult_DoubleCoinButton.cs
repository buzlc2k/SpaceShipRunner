using System.Collections.Generic;

public class GameResult_DoubleCoinButton : BaseButton
{
    protected override void OnClick()
    {
        Observer.PostEvent(EventID.WantToWatch_ADS, new KeyValuePair<EventParameterType, object>(EventParameterType.WantToWatch_ADS_PlacementID, PlacementID.DoubleCoinButton));
        ((GameResultCanvas)GetCanvas()).SetOnlyReloadGameButton();
    }
}