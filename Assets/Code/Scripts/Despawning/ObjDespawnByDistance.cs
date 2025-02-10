using UnityEngine;

/// <summary>
/// Despawning objects based on their distance from a specified spawn position.
/// </summary>
public abstract class ObjDespawnByDistance : ObjDespawning
{  
    protected ObjDespawnByDistanceConfig objDespawningConfig;

    protected override void LoadComponents()
    {
        base.LoadComponents();

        SetObjDespawningConfig();
    }

    protected abstract void SetObjDespawningConfig();

    protected override bool CheckCanDespawn()
    {
        if(Vector3.Distance(objDespawningConfig.PosToCalculateDespawn, transform.parent.position) > objDespawningConfig.DisToDespawn) return true;
        return false;
    }
}