using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SawBladeCtrl : ObstacleCubeCtrl
{
    [Header("SawBladeCtrl")]
    public ObjRotation sawBladeRotation;

    private void Reset() {
        obstacleCubeModel = GetComponentInChildren<MeshRenderer>().transform;
        obstacleCubeMovement = GetComponentInChildren<ObjMovement>();
        obstacleCubeCollision = GetComponentInChildren<ObjCollision>();
        sawBladeRotation = GetComponentInChildren<ObjRotation>();
    }
}