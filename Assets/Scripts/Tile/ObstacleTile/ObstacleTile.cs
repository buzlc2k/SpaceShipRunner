using System;
using UnityEngine;

/// <summary>
/// Defines the attributes of a tile and control a tile.
/// </summary>
public class ObstacleTile : MonoBehaviour, IPooled
{
    public ObjMovement obstacleTileMovement;
    public ObjDespawn obstacleTileDespawn;

    private void Awake() {
        obstacleTileMovement = GetComponent<ObjMovement>();
        obstacleTileDespawn = GetComponent<ObjDespawn>();
    }

    public void Release()
    {
        gameObject.SetActive(false);
        ReleaseCallback?.Invoke(this.gameObject);
    }

    public Action<GameObject> ReleaseCallback { get; set; }
}

