using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Singleton<PlayerController>
{
    public Transform playerModel;
    public ObjMovement playerMovement;

    private void Awake() {
        playerModel = GetComponentInChildren<MeshRenderer>().transform;
        playerMovement = GetComponentInChildren<ObjMovement>();
    }
}
