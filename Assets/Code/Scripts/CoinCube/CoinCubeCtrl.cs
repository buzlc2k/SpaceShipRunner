using UnityEngine;

public class CoinCubeCtrl : ButMonobehavior
{
    [Header("CoinCubeCtrl")]
    public Transform coinCubeModel;
    public ObjMovement coinCubeMovement;
    public ObjRotation coinCubeRotation;
    public ObjCollision coiCubeCollision;
    public ObjDespawning coinCubeDespawning;
    public CoinCubeConfig coinCubeConfig;

    protected override void LoadComponents() {
        base.LoadComponents();
        if (coinCubeModel == null) coinCubeModel = GetComponentInChildren<MeshRenderer>().transform;
        if (coiCubeCollision == null) coiCubeCollision = GetComponentInChildren<ObjCollision>();
        if(coinCubeMovement == null) coinCubeMovement = GetComponentInChildren<ObjMovement>();
        if (coinCubeRotation == null) coinCubeRotation = GetComponentInChildren<ObjRotation>();
        if(coinCubeDespawning == null) coinCubeDespawning = GetComponentInChildren<ObjDespawning>();
    }
}