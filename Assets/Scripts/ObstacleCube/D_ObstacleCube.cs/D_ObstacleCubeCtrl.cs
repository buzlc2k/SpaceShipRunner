using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class D_ObstacleCubeCtrl : ObstacleCubeCtrl
{
    [Header("D_ObstacleCubeCtrl")]
    public ObjMovement obstacleCubeMovement;

    protected override void LoadComponents() {
        base.LoadComponents();
        if (obstacleCubeMovement == null) obstacleCubeMovement = GetComponentInChildren<ObjMovement>();
    }
}