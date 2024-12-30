using UnityEngine;
using System;
using System.Collections.Generic;

public abstract class FX_CollisionSpawner : ButMonobehavior
{
    [Header("FX_CollisionSpawner")]
    [SerializeField] private GameObject FX_CollisionPrefabs;
    [SerializeField] private Transform FX_CollisionHolder;
    private ObjectPooler<FX_CollisionCtrl> fx_CollisionPoolers;
    protected Action<KeyValuePair<EventParameterType, object>> spawnFX_CollisionDelegate;

    protected override void Awake()
    {
        base.Awake();
        fx_CollisionPoolers = new ObjectPooler<FX_CollisionCtrl>(FX_CollisionPrefabs.GetComponent<FX_CollisionCtrl>(), FX_CollisionHolder, 1);
    }

    protected override void OnEnable()
    {
        base.OnEnable();

        SetUpDelegate();
    }

    protected virtual void SetUpDelegate(){
        //noop
    }

    protected void SpawnFX_Collision(GameObject objectCollided){
         Tuple<Vector3, Quaternion> spawnData = GetSpawnData(objectCollided);

        Spawn(objectCollided, spawnData.Item1, spawnData.Item2);
    }

    private Tuple<Vector3, Quaternion> GetSpawnData(GameObject objectCollided){
        var spawnPosition = objectCollided.transform.position;
        var spawnRotation = Quaternion.identity;

        return Tuple.Create<Vector3, Quaternion>(spawnPosition, spawnRotation);
    }

    private void Spawn(GameObject objectCollided, Vector3 spawnPosition, Quaternion spawnRotation){
        FX_CollisionCtrl fx_Collision = fx_CollisionPoolers.Get(spawnPosition, spawnRotation);
    }
}