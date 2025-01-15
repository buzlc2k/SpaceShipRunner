using UnityEngine;
using System;
using System.Collections.Generic;

public class ObstacleTileSpawner : ButMonobehavior
{
    
    [Header("OstacleTilesPrefab")]
    [SerializeField] private Transform obstacleTileHolder;
    private List<ObjectPooler<ObstacleTileCtrl>> obstacleTilePoolers = new();
    private Action<KeyValuePair<EventParameterType, object>> spawnObstacleTileDelegate;
    private Action<KeyValuePair<EventParameterType, object>> addNewObstacleTilePoolerDelegate;

    protected override void SetUpDelegate(){
        spawnObstacleTileDelegate ??= (param) => {
            if (param.Key != EventParameterType.ResetWalkableTile_WalkableTileObject) return;
            SpawnObstacleTile((GameObject)param.Value);
        };

        addNewObstacleTilePoolerDelegate ??= (param) => {
            if (param.Key != EventParameterType.AddMoreObstacle_ListObstaclePrefab) return;
            AddNewObstacleTilePooler((List<GameObject>)param.Value);
        };
    }

    protected override void RegisterListener()
    {
        base.RegisterListener();

        Observer.AddListener(EventID.ResetWalkableTile, spawnObstacleTileDelegate);
        Observer.AddListener(EventID.AddMoreObstacle, addNewObstacleTilePoolerDelegate);
    }

    protected override void UnregisterListener()
    {
        base.UnregisterListener();

        Observer.RemoveListener(EventID.ResetWalkableTile, spawnObstacleTileDelegate);
        Observer.RemoveListener(EventID.AddMoreObstacle, addNewObstacleTilePoolerDelegate);
    }

    private bool CheckCanSpawn(){
        return GameManager.Instance.CurrentGameState.Equals(GameState.Running)
            || GameManager.Instance.CurrentGameState.Equals(GameState.Restarting);
    }

    private void SpawnObstacleTile(GameObject walkableTile){
        if(!CheckCanSpawn()) return;

        Tuple<Vector3, Quaternion> spawnData = GetSpawnData(walkableTile);

        Spawn(walkableTile, spawnData.Item1, spawnData.Item2);
    }

    private void AddNewObstacleTilePooler(List<GameObject> obstacleTilePrefabs){
        foreach(var obstacleTilePrefab in obstacleTilePrefabs){
            var obstacleTilePooler = new ObjectPooler<ObstacleTileCtrl>(obstacleTilePrefab.GetComponent<ObstacleTileCtrl>(), obstacleTileHolder, 2);
            obstacleTilePoolers.Add(obstacleTilePooler);
        }
    }

    private Tuple<Vector3, Quaternion> GetSpawnData(GameObject walkableTile){
        var spawnPosition = walkableTile.transform.position;
        var spawnRotation = Quaternion.identity;

        return Tuple.Create<Vector3, Quaternion>(spawnPosition, spawnRotation);
    }

    private void Spawn(GameObject walkableTile, Vector3 spawnPosition, Quaternion spawnRotation){
        if(obstacleTilePoolers.Count == 0) return;

        ObstacleTileCtrl obstacleTile = obstacleTilePoolers[UnityEngine.Random.Range(0, obstacleTilePoolers.Count)].Get(spawnPosition, spawnRotation);
        
        ((ObstacleTileMoveByTargetTransform)obstacleTile.obstacleTileMovement).SetTargetTransform(walkableTile.transform);

        Observer.PostEvent(EventID.ObstacleTileSpawned, new KeyValuePair<EventParameterType, object>
                                                        (EventParameterType.ObstacleTileSpawned_WalkableTileObjectAndListSpawnPositions,
                                                        Tuple.Create<GameObject, List<Vector3>>(obstacleTile.gameObject, obstacleTile.obstacleTileConfig.AvailablePositionToSpawnItem)));
    }
}