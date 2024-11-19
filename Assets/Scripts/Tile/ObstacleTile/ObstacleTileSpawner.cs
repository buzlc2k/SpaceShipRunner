using UnityEngine;
using System;
using System.Collections.Generic;

public class ObstacleTileSpawner : MonoBehaviour
{
    [Header("OstacleTilesPrefab")]
    [SerializeField] private Transform obstacleTileHolder;
    [SerializeField] List<GameObject> obstacleTilePrefabs = new();
    private List<ObjectPooler<ObstacleTileCtrl>> obstacleTilePoolers = new();

    [Header("SpawnRate")]
    [SerializeField] float spawnRate = 0.3f;

    private Action<KeyValuePair<EventParameterType, object>> spawnObstacleTileDelegate;

    private void Start() {
        foreach(GameObject obstacleTilePrefab in obstacleTilePrefabs) {
            var obstacleTilePooler = new ObjectPooler<ObstacleTileCtrl>(obstacleTilePrefab.GetComponent<ObstacleTileCtrl>(), obstacleTileHolder, 2);
            obstacleTilePoolers.Add(obstacleTilePooler);
        }

        spawnObstacleTileDelegate = (param) => {
            if (param.Key != EventParameterType.ResetWalkableTile_WalkableTileObject) return;
            SpawnObstacleTile((GameObject)param.Value);
        };

        Observer.AddListener(EventID.ResetWalkableTile, spawnObstacleTileDelegate);
    }

    private void OnDestroy() {
        Observer.RemoveListener(EventID.ResetWalkableTile, spawnObstacleTileDelegate);
    }

    private void SpawnObstacleTile(GameObject walkableTile){
        if(UnityEngine.Random.value > spawnRate) return;

        var spawnPosition = walkableTile.transform.position;
        var spawnRotation = Quaternion.identity;

        ObstacleTileCtrl obstacleTile = obstacleTilePoolers[UnityEngine.Random.Range(0, obstacleTilePoolers.Count)].Get(spawnPosition, spawnRotation);

        ((ObstacleTileMoveByTargetTransform)obstacleTile.obstacleTileMovement).SetMoveTarget(walkableTile.transform);
    }
}