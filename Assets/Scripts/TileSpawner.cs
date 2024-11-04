using UnityEngine;
using System;
using System.Collections.Generic;

public class TileSpawner : MonoBehaviour
{
    [Header("Count")]
    [SerializeField] private int tileStartCount = 10;
    [SerializeField] private int minimumStraightTile = 3;
    [SerializeField] private int maxStraightTile = 15;

    #region TileSpawnerData
    private Vector3 currentPositionSpawn = Vector3.zero;
    private Vector3 currentDirectionSpawn = Vector3.forward;
    private readonly List<GameObject> tileSpawneds = new();
    private readonly List<GameObject> obstacleTileSpawneds = new();

    [Header("TilesPrefab")]
    [SerializeField] private GameObject straightTilePrefab;
    [SerializeField] private GameObject leftTilePrefab;
    [SerializeField] private GameObject rightTilePrefab;
    [SerializeField] private GameObject sidewayTilePrefab;
    [SerializeField] private GameObject obstacleTilePrefab;
    [SerializeField] private GameObject slideObstacleTilePrefab;

    #endregion

    [Header("PoolObject")]
    [SerializeField] private Transform tileHolder;
    private ObjectPooler<WalkableTile> _poolStraightTile;
    private List<ObjectPooler<WalkableTile>> crossTilePoolers;
    private List<ObjectPooler<Tile>> obstaclePoolers;

    private void Start()
    {
        _poolStraightTile = new ObjectPooler<WalkableTile>(straightTilePrefab.GetComponent<WalkableTile>(), tileHolder, 5);
        
        crossTilePoolers = new List<ObjectPooler<WalkableTile>>
        {
            new ObjectPooler<WalkableTile>(leftTilePrefab.GetComponent<WalkableTile>(), tileHolder, 5),
            new ObjectPooler<WalkableTile>(rightTilePrefab.GetComponent<WalkableTile>(), tileHolder, 5),
            new ObjectPooler<WalkableTile>(sidewayTilePrefab.GetComponent<WalkableTile>(), tileHolder, 5)
        };

        obstaclePoolers = new List<ObjectPooler<Tile>>
        {
            new ObjectPooler<Tile>(obstacleTilePrefab.GetComponent<Tile>(), tileHolder, 5),
            new ObjectPooler<Tile>(slideObstacleTilePrefab.GetComponent<Tile>(), tileHolder, 5)
        };

        UnityEngine.Random.InitState(DateTime.Now.Millisecond);
        SpawnTileWay(Vector3.forward, true);
    }

    private int GetTileSpawnCount(bool startingSpawn) => startingSpawn ? tileStartCount : UnityEngine.Random.Range(minimumStraightTile, maxStraightTile);

    public void SpawnTileWay(Vector3 direction, bool startingSpawn = false)
    {
        DeletePreviousTileWay(startingSpawn);

        currentDirectionSpawn = direction;
        int numTileSpawn = GetTileSpawnCount(startingSpawn);

        for (int i = 0; i < numTileSpawn; i++)
        {
            SpawnWalkableTile(_poolStraightTile);
            if (!startingSpawn) SpawnObstacleTile();
        }

        SpawnWalkableTile(crossTilePoolers[UnityEngine.Random.Range(0, crossTilePoolers.Count)]);
    }

    private void SpawnObstacleTile()
    {
        if (UnityEngine.Random.value > 0.3f) return;

        var tilePooler = obstaclePoolers[UnityEngine.Random.Range(0, obstaclePoolers.Count)];
        Quaternion newRotation = tilePooler.PoolPrefab.transform.rotation * Quaternion.LookRotation(currentDirectionSpawn);
        GameObject obstacleTile = tilePooler.Get(currentPositionSpawn, newRotation).gameObject;

        obstacleTileSpawneds.Add(obstacleTile);
    }

    private void SpawnWalkableTile(ObjectPooler<WalkableTile> tilePooler)
    {
        WalkableTile tilePrefab = tilePooler.PoolPrefab.GetComponent<WalkableTile>();
        WalkableTile prevTile = tileSpawneds.Count > 0 ? tileSpawneds[^1].GetComponent<WalkableTile>() : null;

        Quaternion newRotation = tilePrefab.transform.rotation * Quaternion.LookRotation(currentDirectionSpawn);
        currentPositionSpawn += Vector3.Scale(
            prevTile != null ? tilePrefab.offsetFromPreviousTile + prevTile.offsetToNextTile : tilePrefab.offsetFromPreviousTile,
            currentDirectionSpawn
        );

        GameObject newTile = tilePooler.Get(currentPositionSpawn, newRotation).gameObject;
        tileSpawneds.Add(newTile);
    }

    private void DeletePreviousTileWay(bool startingSpawn)
    {
        while (tileSpawneds.Count > 1)
        {
            var tile = tileSpawneds[0];
            tileSpawneds.RemoveAt(0);
            tile.GetComponent<Tile>().Release();
        }

        if (startingSpawn) return;

        while (obstacleTileSpawneds.Count > 0)
        {
            var obstacleTile = obstacleTileSpawneds[0];
            obstacleTileSpawneds.RemoveAt(0);
            obstacleTile.GetComponent<Tile>().Release();
        }
    }
}

