using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/ObjectConfig/FX_CollisionCofig")]
public class FX_CollisionCofig : ScriptableObject
{
    [Header("Movement")]
    public float InitialMoveSpeed;

    [Header("Despawning")]
    public float InitialTimeToDespawn;
}