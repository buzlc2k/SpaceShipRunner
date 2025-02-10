using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/ObjectConfig/VFXConfig/VFXConfig")]
public class VFXConfig : ScriptableObject
{
    [Header("Despawning")]
    public ObjDespawnByTimeConfig VFXDespawningConfig;
}