using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : Singleton<PlayerCtrl>
{
    public Transform playerModel;
    public ObjMovement playerMovement;
    public ObjRotation playerRotation;
    public ObjCollision playerCollision;

    private void Reset() {
        playerModel = GetComponentInChildren<MeshRenderer>().transform;
        playerMovement = GetComponentInChildren<ObjMovement>();
        playerRotation = GetComponentInChildren<ObjRotation>();
        playerCollision = GetComponentInChildren<ObjCollision>();
    }
}
