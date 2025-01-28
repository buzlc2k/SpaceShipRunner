using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/AudioConfig/AudioManagerConfig")]

public class AudioManagerConfig : ScriptableObject
{
    public List<BaseAudioCtrl> AudioCtrls = new();
}