using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/AudioConfig/UnLoopAudioConfig")]

public class UnLoopAudioConfig : AudioConfig
{
    public ObjDespawnByTimeConfig AudioDespawningConfig;
}