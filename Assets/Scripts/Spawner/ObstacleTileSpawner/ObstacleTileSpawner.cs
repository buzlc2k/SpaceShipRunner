using UnityEngine;
using System;
using System.Collections.Generic;

public class ObstacleTileSpawner : MonoBehaviour
{
    
    [Header("OstacleTilesPrefab")]
    [SerializeField] private Transform obstacleTileHolder;
    private List<ObjectPooler<ObstacleTileCtrl>> obstacleTilePoolers = new();
    private Action<KeyValuePair<EventParameterType, object>> spawnObstacleTileDelegate;
    private Action<KeyValuePair<EventParameterType, object>> createListObstacleTilePoolerDelegate;

    private void Start() {
        spawnObstacleTileDelegate = (param) => {
            if (param.Key != EventParameterType.ResetWalkableTile_WalkableTileObject) return;
            SpawnObstacleTile((GameObject)param.Value);
        };

        createListObstacleTilePoolerDelegate = (param) => {
            if (param.Key != EventParameterType.AddMoreObstacle_ListObstaclePrefab) return;
            CreateListObstacleTilePooler((List<GameObject>)param.Value);
        };

        Observer.AddListener(EventID.ResetWalkableTile, spawnObstacleTileDelegate);
        Observer.AddListener(EventID.AddMoreObstacle, createListObstacleTilePoolerDelegate);
    }

    private void OnDestroy() {
        Observer.RemoveListener(EventID.ResetWalkableTile, spawnObstacleTileDelegate);
        Observer.RemoveListener(EventID.AddMoreObstacle, createListObstacleTilePoolerDelegate);
    }

    private void SpawnObstacleTile(GameObject walkableTile){
        var spawnPosition = walkableTile.transform.position;
        var spawnRotation = Quaternion.identity;

        ObstacleTileCtrl obstacleTile = obstacleTilePoolers[UnityEngine.Random.Range(0, obstacleTilePoolers.Count)].Get(spawnPosition, spawnRotation);
        
        ((ObstacleTileMoveByTargetTransform)obstacleTile.obstacleTileMovement).SetMoveTarget(walkableTile.transform);
    }

    private void CreateListObstacleTilePooler(List<GameObject> obstacleTilePrefabs){
        foreach(var obstacleTilePrefab in obstacleTilePrefabs){
            var obstacleTilePooler = new ObjectPooler<ObstacleTileCtrl>(obstacleTilePrefab.GetComponent<ObstacleTileCtrl>(), obstacleTileHolder, 2);
            obstacleTilePoolers.Add(obstacleTilePooler);
        }
    }
}