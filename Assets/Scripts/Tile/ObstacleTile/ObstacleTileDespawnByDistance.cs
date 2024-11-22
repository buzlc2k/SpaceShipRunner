using UnityEngine;

/// <summary>
/// Despawning Obstacle Tile based on their distance from a specified spawn position.
/// </summary>
public class ObstacleTileDespawnByDistance: ObjDespawnByDistance
{
    protected override object GetObjCtrl()
    {
        return this.transform.parent.GetComponent<ObstacleTileCtrl>();
    }
}