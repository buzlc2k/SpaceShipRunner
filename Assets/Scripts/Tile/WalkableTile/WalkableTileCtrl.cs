using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkableTileCtrl : ButMonobehavior
{
    public Transform walkableModel;
    public ObjMovement walkableMovement;
    public WalkableTileConfig walkableTileConfig;

    protected override void LoadComponents() {
        if(walkableModel == null) walkableModel = GetComponentInChildren<MeshRenderer>().transform;
        if(walkableMovement == null) walkableMovement = GetComponentInChildren<ObjMovement>();
    }
}