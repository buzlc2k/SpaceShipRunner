using UnityEngine;

/// <summary>
/// Despawning objects based on their distance from a specified spawn position.
/// </summary>
public abstract class ObjDespawnByDistance : ObjDespawning
{
    [Header("ObjDespawnByDistance")]
    protected Vector3 posToCalculateDespawn;
    protected float disToDespawn;

    protected override bool CheckCanDespawn()
    {
        if(Vector3.Distance(posToCalculateDespawn, transform.parent.position) > disToDespawn) return true;
        return false;
    }
}