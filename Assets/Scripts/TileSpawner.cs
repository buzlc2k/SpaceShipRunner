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
    GameObject prevTile;
    #endregion

    private void Start() {
        prevTile = straightTilePrefab;

        UnityEngine.Random.InitState(System.DateTime.Now.Millisecond);

        SpawnTileWay(true);
    }

    private int GetTileSpawnCount(bool startingSpawn) {
        return startingSpawn ? tileStartCount : UnityEngine.Random.Range(minimumStraightTile, maxStraightTile);
    }

    public void SpawnTileWay(bool startingSpawn = false){
        int numTileSpawn = GetTileSpawnCount(startingSpawn);
        //spawn straight tile
        for(int i = 0; i < numTileSpawn; i++)
        {
            SpawnOneTile(straightTilePrefab);
        }
        //spawn cross tile
        SpawnOneTile(crossTilePrefabs[UnityEngine.Random.Range(0, crossTilePrefabs.Count)]);
    }

    public void SpawnOneTile(GameObject tile, bool spawnObstacle = false){
        var tileComponent = tile.GetComponent<Tile>();
        var prevTileComponent = prevTile.GetComponent<Tile>();
        //Get quaternion to spawn 1 tile from forward dir to its correct dir spawn and current direction
        Quaternion newTileRotation = tile.transform.rotation * Quaternion.LookRotation(currentDirectionSpawn);
        //Get spawn pos equal default local vector between pivot 2 tiles * quaternion
        currentPositionSpawn += Vector3.Scale(tileComponent.offsetFromPreviousTile + prevTileComponent.offsetToNextTile, currentDirectionSpawn);

        GameObject tileSpawned = PoolObject.GetPoolObject(tile).GetObjectInPool();
        tileSpawned.transform.SetPositionAndRotation(currentPositionSpawn, newTileRotation);
        tileSpawned.SetActive(true);

        prevTile = tileSpawned;
    }
}
