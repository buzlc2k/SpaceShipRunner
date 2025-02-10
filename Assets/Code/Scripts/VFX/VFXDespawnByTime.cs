using UnityEngine;

/// <summary>
/// Despawning FX_Collision based on their distance from a specified spawn position.
/// </summary>
public class VFXDespawnByTime: ObjDespawnByTime
{
    protected override object GetObjCtrl()
    {
        return transform.parent.GetComponent<VFXCtrl>();
    }

    protected override void SetObjDespawningConfig()
    {
        objDespawningConfig = ((VFXCtrl)GetObjCtrl()).vfxConfig.VFXDespawningConfig;
    }
}