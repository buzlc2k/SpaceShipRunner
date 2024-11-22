using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkableTileCtrl : MonoBehaviour
{
    public Transform walkableModel;
    public ObjMovement walkableMovement;

    private void Reset() {
        walkableModel = GetComponentInChildren<MeshRenderer>().transform;
        walkableMovement = GetComponentInChildren<ObjMovement>();
    }
}