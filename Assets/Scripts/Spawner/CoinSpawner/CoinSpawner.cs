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

    protected override void Awake()
    {
        base.Awake();
        coinPooler = new ObjectPooler<CoinCtrl>(coinPrefab.GetComponent<CoinCtrl>(), coinHolder, 10);
    }

    protected override void Start()
    {
        spawnCoinDelegate = (param) => {
            if(param.Key != EventParameterType.ObstacleTileSpawned_WalkableTileObjectAndListSpawnPositions) return;

            SpawnCoin(((Tuple<GameObject, List<Vector3>>)param.Value).Item1, ((Tuple<GameObject, List<Vector3>>)param.Value).Item2);
        };

        Observer.AddListener(EventID.ObstacleTileSpawned, spawnCoinDelegate);
    }

    private void OnDestroy() {
        Observer.RemoveListener(EventID.ObstacleTileSpawned, spawnCoinDelegate);
    }

    private void SpawnCoin(GameObject obstacleTile ,List<Vector3> spawnPositions){
        for(int i = 0; i < 4; i++){
            if(UnityEngine.Random.value > 0.5) continue;

            var offsetPoint = spawnPositions[UnityEngine.Random.Range(0, spawnPositions.Count)];
            var spawnPosition = obstacleTile.transform.position + offsetPoint;
            var spawnRotation = Quaternion.identity;

            CoinCtrl coin = coinPooler.Get(spawnPosition, spawnRotation);

            ((CoinMoveByTargetTransformWithOffset)coin.coinMovement).SetOffsetPoint(offsetPoint);
            ((CoinMoveByTargetTransformWithOffset)coin.coinMovement).SetTargetTransform(obstacleTile.transform);
        }
    }
}