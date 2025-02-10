using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/ObjectConfig/ObjDespawningConfig/ObjDespawnByTimeConfig")]
public class ObjDespawnByTimeConfig : ObjDespawningConfig
{
    public float TimeToDespawn;
}