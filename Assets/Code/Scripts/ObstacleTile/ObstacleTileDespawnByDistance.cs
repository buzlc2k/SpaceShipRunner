using UnityEngine;

/// <summary>
/// Despawning Obstacle Tile based on their distance from a specified spawn position.
/// </summary>
public class ObstacleTileDespawnByDistance: ObjDespawnByDistance
{
    protected override void LoadValue(){
        base.LoadValue();

        disToDespawn = ((ObstacleTileCtrl)GetObjCtrl()).obstacleTileConfig.InitialDisToDespawn;
        posToCalculateDespawn = ((ObstacleTileCtrl)GetObjCtrl()).obstacleTileConfig.InitialPosToCalculateDespawn;
    }

    protected override object GetObjCtrl()
    {
        return this.transform.parent.GetComponent<ObstacleTileCtrl>();
    }
}