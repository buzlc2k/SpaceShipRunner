using UnityEngine;

/// <summary>
/// Despawning Obstacle Tile based on their distance from a specified spawn position.
/// </summary>
public class ObstacleTileDespawnByDistance: ObjDespawnByDistance
{
    protected override object GetObjCtrl()
    {
        return transform.parent.GetComponent<ObstacleTileCtrl>();
    }

    protected override void SetObjDespawningConfig()
    {
        objDespawningConfig = (ObjDespawnByDistanceConfig)((ObstacleTileCtrl)GetObjCtrl()).obstacleTileConfig.ObstacleTileDespawnConfig;
    }
}