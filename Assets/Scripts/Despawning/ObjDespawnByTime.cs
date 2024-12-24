using UnityEngine;

/// <summary>
/// Despawning objects based on their life time.
/// </summary>
public abstract class ObjDespawnByTime : ObjDespawning
{
    [Header("ObjDespawnByTime")]
    protected float timeToDespawn;

    protected override bool CheckCanDespawn()
    {
        timeToDespawn -= Time.deltaTime;
        
        if(timeToDespawn < 0) return true;
        return false;
    }
}