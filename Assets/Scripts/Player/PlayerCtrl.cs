using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : Singleton<PlayerCtrl>
{
    public Transform playerModel;
    public ObjMovement playerMovement;
    public ObjRotation playerRotation;

    private void Awake() {
        playerModel = GetComponentInChildren<MeshRenderer>().transform;
        playerMovement = GetComponentInChildren<ObjMovement>();
        playerRotation = GetComponentInChildren<ObjRotation>();
    }
}
