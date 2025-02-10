using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/ObjectConfig/ObjDespawningConfig/ObjDespawnByDistanceConfig")]
public class ObjDespawnByDistanceConfig : ObjDespawningConfig
{
    public Vector3 PosToCalculateDespawn;
    public float DisToDespawn;
}