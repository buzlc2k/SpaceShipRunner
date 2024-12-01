using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SawBladeCtrl : D_ObstacleCubeCtrl
{
    [Header("SawBladeCtrl")]
    public ObjRotation sawBladeRotation;

    protected override void LoadComponents() {
        base.LoadComponents();
        if(sawBladeRotation == null) sawBladeRotation = GetComponentInChildren<ObjRotation>();
    }
}