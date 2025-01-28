using System;
using UnityEngine;

public class WorldVFXCtrl : VFXCtrl
{
    public ObjMovement worldVFXMovement;
    protected override void LoadComponents() {
        base.LoadComponents();

        if(worldVFXMovement == null) worldVFXMovement = GetComponentInChildren<ObjMovement>();
    }
}