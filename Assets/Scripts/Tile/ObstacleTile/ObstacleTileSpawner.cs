using UnityEngine;
using System;
using System.Collections.Generic;

public class ObstacleTileSpawner : MonoBehaviour
{
    [Header("OstacleTilesPrefab")]
    [SerializeField] private Transform tileHolder;
    [SerializeField] List<GameObject> obstacleTilePrefabs = new();
    private List<ObjectPooler<ObstacleTile>> obstacleTilePoolers;

    private Action<KeyValuePair<EventParameterType, object>> spawnObstacleTileDelegate;

    private void Start() {
        foreach(GameObject obstacleTilePrefab in obstacleTilePrefabs) {
            var obstacleTilePooler = new ObjectPooler<ObstacleTile>(obstacleTilePrefab.GetComponent<ObstacleTile>(), tileHolder, 2);
            obstacleTilePoolers.Add(obstacleTilePooler);
        }

        spawnObstacleTileDelegate = (param) => {
            if (param.Key != EventParameterType.ResetWalkableTile_WalkableTileObject) return;
            SpawnObstacleTile((GameObject)param.Value);
        };
    }

    private void OnEnable() {
        Observer.AddListener(EventID.ResetWalkableTile, spawnObstacleTileDelegate);
    }

    private void OnDisable() {
        Observer.RemoveListener(EventID.ResetWalkableTile, spawnObstacleTileDelegate);
    }

    public void SpawnObstacleTile(GameObject walkableTile){
        for(int i = 0; i < 2; i++){
            if(UnityEngine.Random.value < 0.5f) continue;
            
            var spawnPosition = walkableTile.transform.position + i * 4 * Vector3.forward;
            var spawnRotation = Quaternion.identity;

            ObstacleTile obstacleTile = obstacleTilePoolers[UnityEngine.Random.Range(0, obstacleTilePoolers.Count - 1)].Get(spawnPosition, spawnRotation);

            ((ObstacleTileMoveForward)obstacleTile.obstacleTileMovement).SetMoveTarget(walkableTile.transform);
        }
    }
}