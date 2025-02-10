using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/ObjectConfig/CoinConfig")]
public class CoinConfig : ScriptableObject
{
    [Header("Movement")]
    public ObjMovementConfig CoinMovementConfig;

    [Header("Despawning")]
    public ObjDespawnByDistanceConfig CoinDespawningConfig;
}