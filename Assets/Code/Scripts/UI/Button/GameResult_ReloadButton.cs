using System.Collections.Generic;

public class GameResult_ReloadButton : BaseButton
{
    protected override void OnClick()
    {
        Observer.PostEvent(EventID.ButtonReloadGame_Click, new KeyValuePair<EventParameterType, object>(EventParameterType.ButtonReloadGame_Click_Null, null));
    }
}