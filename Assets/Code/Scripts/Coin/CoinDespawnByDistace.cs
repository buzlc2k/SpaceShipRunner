using UnityEngine;

/// <summary>
/// Despawning coin based on their distance from a specified spawn position.
/// </summary>
public class CoinDespawnByDistace: ObjDespawnByDistance
{
    protected override object GetObjCtrl()
    {
        return transform.parent.GetComponent<CoinCtrl>();
    }

    protected override void SetObjDespawningConfig()
    {
        objDespawningConfig = ((CoinCtrl)GetObjCtrl()).coinConfig.CoinDespawningConfig;
    }
}