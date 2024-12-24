using UnityEngine;

/// <summary>
/// Despawning FX_Collision based on their distance from a specified spawn position.
/// </summary>
public class FX_CollisionDespawnByTime: ObjDespawnByTime
{
    protected override void LoadValue(){
        base.LoadValue();

        timeToDespawn = ((FX_CollisionCtrl)GetObjCtrl()).fxConfig.InitialTimeToDespawn;
    }

    protected override object GetObjCtrl()
    {
        return this.transform.parent.GetComponent<FX_CollisionCtrl>();
    }
}