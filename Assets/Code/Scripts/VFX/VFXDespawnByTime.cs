using UnityEngine;

/// <summary>
/// Despawning FX_Collision based on their distance from a specified spawn position.
/// </summary>
public class VFXDespawnByTime: ObjDespawnByTime
{
    protected override void LoadValue(){
        base.LoadValue();

        timeToDespawn = ((VFXCtrl)GetObjCtrl()).vfxConfig.InitialTimeToDespawn;
    }

    protected override object GetObjCtrl()
    {
        return this.transform.parent.GetComponent<VFXCtrl>();
    }
}