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
    #endregion

    private void Start() {
        UnityEngine.Random.InitState(System.DateTime.Now.Millisecond);

        for (int i = 0; i <= tileStartCount; i++){
            SpawnTile(straightTilePrefab);
        }

        SpawnTile(crossTilePrefabs[1]);
    }

    public void SpawnTile(GameObject tile, bool spawnObstacle = false){
        Quaternion newTileRotation = tile.transform.rotation * Quaternion.LookRotation(currentDirectionSpawn);
        GameObject tileSpawned = Instantiate(tile, currentPositionSpawn, newTileRotation);
        tileSpawneds.Add(tileSpawned);
        currentPositionSpawn += Vector3.Scale(tileSpawned.GetComponent<Renderer>().bounds.size, currentDirectionSpawn);
    }
}