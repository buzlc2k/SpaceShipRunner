using System.Collections.Generic;
using UnityEngine;

public class AudioSaver : BaseSaver
{
    public override void LoadData(){
        Observer.PostEvent(EventID.LoadAudioEnableData, new KeyValuePair<EventParameterType, object>(EventParameterType.LoadAudioEnableData_AudioEnable, SaveGameManager.Instance.GameDataSaved.AudioEnable));
    }
    public override void SaveData(){
        SaveGameManager.Instance.GameDataSaved.AudioEnable = AudioTrackingManager.Instance.CurrentAudioEnable;
    }
}