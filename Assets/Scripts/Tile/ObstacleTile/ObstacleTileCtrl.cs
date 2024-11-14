using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// Defines the attributes of a tile and control a tile.
/// </summary>
public class ObstacleTileCtrl : MonoBehaviour, IPooled
{
    public Transform[] obstacleModel;
    public ObjMovement obstacleTileMovement;
    public ObjDespawn obstacleTileDespawn;

    private void Awake() {
        obstacleModel = GetComponentsInChildren<MeshRenderer>()
               .Select(meshRenderer => meshRenderer.transform)
               .ToArray();
        obstacleTileMovement = GetComponentInChildren<ObjMovement>();
        obstacleTileDespawn = GetComponentInChildren<ObjDespawn>();
    }

    public void Release()
    {
        gameObject.SetActive(false);
        ReleaseCallback?.Invoke(this.gameObject);
    }

    public Action<GameObject> ReleaseCallback { get; set; }
}

