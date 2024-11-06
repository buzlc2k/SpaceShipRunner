using UnityEngine;
using System;
using System.Collections.Generic;

public class ObstacleTileSpawner : MonoBehaviour
{
    [Header("OstacleTilesPrefab")]
    [SerializeField] private Transform tileHolder;
    [SerializeField] List<GameObject> obstacleTilePrefabs = new();
    private List<ObjectPooler<ObstacleTile>> obstacleTilePoolers;

    private void Start() {
        foreach(GameObject obstacleTilePrefab in obstacleTilePrefabs) {
            var obstacleTilePooler = new ObjectPooler<ObstacleTile>(obstacleTilePrefab.GetComponent<ObstacleTile>(), tileHolder, 2);
            obstacleTilePoolers.Add(obstacleTilePooler);
        }
    }

    
}