using UnityEngine;

/// <summary>
/// Despawning coin based on their distance from a specified spawn position.
/// </summary>
public class CoinDespawnByDistace: ObjDespawnByDistance
{
    protected override void LoadValue(){
        base.LoadValue();

        disToDespawn = ((CoinCtrl)GetObjCtrl()).coinConfig.InitialDisToDespawn;
        posToCalculateDespawn = ((CoinCtrl)GetObjCtrl()).coinConfig.InitialPosToCalculateDespawn;
    }

    protected override object GetObjCtrl()
    {
        return this.transform.parent.GetComponent<CoinCtrl>();
    }
}