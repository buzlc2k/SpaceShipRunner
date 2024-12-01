using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : Singleton<PlayerCtrl>
{
    public Transform playerModel;
    public ObjMovement playerMovement;
    public ObjRotation playerRotation;
    public ObjCollision playerCollision;
    public PlayerConfig playerConfig;
    protected override void LoadComponents()
    {
        base.LoadComponents();

        if(playerModel == null) playerModel = GetComponentInChildren<MeshRenderer>().transform;
        if(playerMovement == null) playerMovement = GetComponentInChildren<ObjMovement>();
        if(playerRotation == null) playerRotation = GetComponentInChildren<ObjRotation>();
        if(playerCollision == null) playerCollision = GetComponentInChildren<ObjCollision>();
    }

    protected override void ResetValue()
    {
        base.ResetValue();

        foreach(Transform child in transform){
            if(!child.gameObject.activeSelf) child.gameObject.SetActive(true);
        }
    }
}
