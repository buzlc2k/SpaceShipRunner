using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObstacleCubeCtrl : MonoBehaviour
{
    [Header("ObstacleCubeCtrl")]
    public Transform obstacleCubeModel;
    public ObjMovement obstacleCubeMovement;
    public ObjCollision obstacleCubeCollision;

    private void Reset() {
        obstacleCubeModel = GetComponentInChildren<MeshRenderer>().transform;
        obstacleCubeMovement = GetComponentInChildren<ObjMovement>();
        obstacleCubeCollision = GetComponentInChildren<ObjCollision>();
    }
}