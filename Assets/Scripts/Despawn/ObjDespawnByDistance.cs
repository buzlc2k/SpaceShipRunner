using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// </summary>
public class ObjDespawnByDistance : ObjDespawn
{
    [Header("ObjDespawnByDistance")]
    [SerializeField] protected Vector3 spawnPos;
    [SerializeField] protected float disToDespawn;

    /// <summary>
    /// 
    /// </summary>
    protected override bool CanDespawn()
    {
        if(Vector3.Distance(this.spawnPos, this.transform.parent.position) > disToDespawn) return true;
        return false;
    }
}