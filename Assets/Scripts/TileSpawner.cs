using UnityEngine;
using System;
using System.Collections.Generic;

public class TileSpawner : MonoBehaviour
{
    [Header("Count")]
    [SerializeField] private int tileStartCount = 10;
    [SerializeField] private int minimumStraightTile = 3;
    [SerializeField] private int maxStraightTile = 15;

    [Header("Tiles")]
    [SerializeField] private GameObject straightTilePrefab;
    [SerializeField] private List<GameObject> crossTilePrefabs = new();
    [SerializeField] private List<GameObject> obstaclePrefabs = new();

    #region TileSpawnerData
    private Vector3 currentPositionSpawn = Vector3.zero;
    private Vector3 currentDirectionSpawn = Vector3.forward;
    List<GameObject> tileSpawneds = new();
    List<GameObject> obstacleTileSpawneds = new();
    #endregion

    private void Start() {
        tileSpawneds.Add(PoolObject.GetPoolObject(straightTilePrefab).GetObjectInPool());
        obstacleTileSpawneds.Add(PoolObject.GetPoolObject(obstaclePrefabs[0]).GetObjectInPool());

        UnityEngine.Random.InitState(System.DateTime.Now.Millisecond);

        SpawnTileWay(Vector3.forward, true);
    }

    private int GetTileSpawnCount(bool startingSpawn) {
        return startingSpawn ? tileStartCount : UnityEngine.Random.Range(minimumStraightTile, maxStraightTile);
    }

    public void SpawnTileWay(Vector3 direction, bool startingSpawn = false){
        DeletePreviousTileWay(startingSpawn);

        currentDirectionSpawn = direction;

        int numTileSpawn = GetTileSpawnCount(startingSpawn);
        //spawn straight tile
        for(int i = 0; i < numTileSpawn; i++)
        {
            SpawnOneTile(straightTilePrefab);
            if(!startingSpawn) SpawnOneObstacleTile();
        }
        //spawn cross tile
        SpawnOneTile(crossTilePrefabs[UnityEngine.Random.Range(0, crossTilePrefabs.Count - 1)]);
    }

    public void SpawnOneObstacleTile()
    {
        if(UnityEngine.Random.value > 0.3f) return; 
        var obstacleTilePrefab = obstaclePrefabs[UnityEngine.Random.Range(0, crossTilePrefabs.Count - 1)];

        Quaternion newTileRotation = obstacleTilePrefab.transform.rotation * Quaternion.LookRotation(currentDirectionSpawn);

        GameObject obstacleTileSpawned = PoolObject.GetPoolObject(obstacleTilePrefab).GetObjectInPool();
        obstacleTileSpawned.transform.SetPositionAndRotation(currentPositionSpawn, newTileRotation);
        obstacleTileSpawned.SetActive(true);

        obstacleTileSpawneds.Add(obstacleTileSpawned);
    }

    public void SpawnOneTile(GameObject tilePrefab){
        var tileComponent = tilePrefab.GetComponent<Tile>();
        var prevTileComponent = tileSpawneds[^1].GetComponent<Tile>();
        //Get quaternion to spawn 1 tile from forward dir to its correct dir spawn and current direction
        Quaternion newTileRotation = tilePrefab.transform.rotation * Quaternion.LookRotation(currentDirectionSpawn);
        //Get spawn pos equal default local vector between pivot 2 tiles * quaternion
        currentPositionSpawn += Vector3.Scale(tileComponent.offsetFromPreviousTile + prevTileComponent.offsetToNextTile, currentDirectionSpawn);

        GameObject tileSpawned = PoolObject.GetPoolObject(tilePrefab).GetObjectInPool();
        tileSpawned.transform.SetPositionAndRotation(currentPositionSpawn, newTileRotation);
        tileSpawned.SetActive(true);

        tileSpawneds.Add(tileSpawned);
    }

    public void DeletePreviousTileWay(bool startingSpawn = false){
        while(tileSpawneds.Count != 1) {
            var tile = tileSpawneds[0];
            tileSpawneds.RemoveAt(0);
            tile.SetActive(false); 
        }
        if(startingSpawn) return;
        while(obstacleTileSpawneds.Count != 0){
            var obstacleTile = tileSpawneds[0];
            obstacleTileSpawneds.RemoveAt(0);
            obstacleTile.SetActive(false); 
        }
    }
}
