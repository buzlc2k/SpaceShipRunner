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

    public void SpawnTileWay(bool startingSpawn = false){        
        //Setting Num TileSpawn In Wave
        int numTileSpawn = 0;
        if(startingSpawn) numTileSpawn = tileStartCount;
        else numTileSpawn = UnityEngine.Random.Range(minimumStraightTile, maxStraightTile);

        //spawn straight
        for(int i = 0; i < numTileSpawn; i++)
        {
            SpawnOneTile(straightTilePrefab);
        }

        SpawnOneTile(crossTilePrefabs[1]);
        currentDirectionSpawn = Vector3.left;
        SpawnOneTile(straightTilePrefab);
    }

    public void SpawnOneTile(GameObject tile, bool spawnObstacle = false){
        //Get quaternion to current direction
        Quaternion newTileRotation = tile.transform.rotation * Quaternion.LookRotation(currentDirectionSpawn);

        currentPositionSpawn += Vector3.Scale(tile.GetComponent<Tile>().prevSpawnVector + prevTile.GetComponent<Tile>().conSpawnVector, currentDirectionSpawn);
        
        GameObject tileSpawned = Instantiate(tile, currentPositionSpawn, newTileRotation);

        prevTile = tileSpawned;
    }
}