using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FX_CollisionCtrl : ButMonobehavior, IPooled
{
    public Transform fxPartical;
    public ObjMovement fxMovement;
    public ObjDespawning fxDespawn;
    public FX_CollisionCofig fxConfig;

    protected override void LoadComponents() {
        base.LoadComponents();
        
        if(fxPartical == null) fxPartical = GetComponentInChildren<ParticleSystem>().transform;
        if(fxMovement == null) fxMovement = GetComponentInChildren<ObjMovement>();
        if(fxDespawn == null) fxDespawn = GetComponentInChildren<ObjDespawning>();
    }

    public Action<GameObject> ReleaseCallback { get; set; }
}