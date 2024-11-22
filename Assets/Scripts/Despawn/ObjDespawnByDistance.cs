using UnityEngine;

/// <summary>
/// Despawning objects based on their distance from a specified spawn position.
/// </summary>
public abstract class ObjDespawnByDistance : ObjDespawn
{
    [Header("ObjDespawnByDistance")]
    [SerializeField] protected Vector3 spawnPos;
    [SerializeField] protected float disToDespawn;

    protected override bool CanDespawn()
    {
        if(Vector3.Distance(this.spawnPos, this.transform.parent.position) > disToDespawn) return true;
        return false;
    }
}