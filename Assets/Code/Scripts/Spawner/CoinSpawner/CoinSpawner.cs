using UnityEngine;
using System;
using System.Collections.Generic;

public class CoinSpawner : ButMonobehavior
{
    
    [Header("CoinPrefab")]
    [SerializeField] private GameObject coinPrefab;
    [SerializeField] private Transform coinHolder;
    private ObjectPooler<CoinCtrl> coinPooler;
    private Action<KeyValuePair<EventParameterType, object>> spawnCoinDelegate;

    protected override void LoadComponents()
    {
        base.LoadComponents();

        coinPooler = new ObjectPooler<CoinCtrl>(coinPrefab.GetComponent<CoinCtrl>(), coinHolder, 10);
    }

    protected override void SetUpDelegate(){
        spawnCoinDelegate ??= (param) => {
            SpawnCoin(((Tuple<GameObject, List<Vector3>>)param.Value).Item1, ((Tuple<GameObject, List<Vector3>>)param.Value).Item2);
        };
    }

    protected override void RegisterListener()
    {
        base.RegisterListener();

        Observer.AddListener(EventID.ObstacleTileSpawned, spawnCoinDelegate);
    }

    protected override void UnregisterListener()
    {
        base.UnregisterListener();

        Observer.RemoveListener(EventID.ObstacleTileSpawned, spawnCoinDelegate);
    }

    private bool CheckCanSpawn(){
        return GameManager.Instance.CurrentGameState.Equals(GameState.Running)
            || GameManager.Instance.CurrentGameState.Equals(GameState.Restarting);
    }

    private void SpawnCoin(GameObject obstacleTile, List<Vector3> spawnPositions)
    {
        if(!CheckCanSpawn()) return;
        // Clone danh sách vị trí spawn để không thay đổi danh sách gốc
        var cloneSpawnPositions = new List<Vector3>(spawnPositions);

        for (int i = 0; i < spawnPositions.Count * DifficultyManager.Instance.NumCoinSpawnedRate; i++)
        {
            if(UnityEngine.Random.value > DifficultyManager.Instance.CoinSpawnRate) return;

            Tuple<int, Vector3> spawnData = GetSpawnData(obstacleTile, cloneSpawnPositions);

            Spawn(spawnData.Item2);

            RemoveSpawnDataUsed(cloneSpawnPositions, spawnData.Item1);
        }
    }

    private Tuple<int, Vector3> GetSpawnData(GameObject obstacleTile, List<Vector3> cloneSpawnPositions){
        int randomIndex = UnityEngine.Random.Range(0, cloneSpawnPositions.Count);
        Vector3 offsetPoint = cloneSpawnPositions[randomIndex];
        Vector3 spawnPosition = obstacleTile.transform.position + offsetPoint;

        return Tuple.Create<int, Vector3>(randomIndex, spawnPosition);
    }

    private void Spawn(Vector3 spawnPosition){
        var coin = coinPooler.Get(spawnPosition, Quaternion.identity);
    }

    private void RemoveSpawnDataUsed(List<Vector3> cloneSpawnPositions, int indexToRemove){
        cloneSpawnPositions[indexToRemove] = cloneSpawnPositions[^1];
        cloneSpawnPositions.RemoveAt(cloneSpawnPositions.Count - 1);
    }
}