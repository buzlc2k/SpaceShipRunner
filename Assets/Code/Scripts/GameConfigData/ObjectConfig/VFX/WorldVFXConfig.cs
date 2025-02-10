using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/ObjectConfig/VFXConfig/WorldVFXConfig")]
public class WorldVFXConfig : VFXConfig
{
    [Header("Movement")]
    public ObjMovementConfig VFXMovementConfig;
}