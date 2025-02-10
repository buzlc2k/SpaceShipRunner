using UnityEngine;

/// <summary>
/// Despawning objects based on their life time.
/// </summary>
public abstract class ObjDespawnByTime : ObjDespawning
{
    protected ObjDespawnByTimeConfig objDespawningConfig;
    protected float currentTime;

    protected override void LoadComponents() {
        base.LoadComponents();

        SetObjDespawningConfig();
    }

    protected override void LoadValue()
    {
        base.LoadValue();

        currentTime = objDespawningConfig.TimeToDespawn;
    }

    protected abstract void SetObjDespawningConfig();

    protected override bool CheckCanDespawn()
    {
        currentTime -= Time.deltaTime;
        
        if(currentTime < 0) return true;
        return false;
    }
}