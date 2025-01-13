using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class VFXCtrl : ButMonobehavior, IPooled
{
    public Transform vfxPartical;
    public ObjMovement vfxMovement;
    public ObjDespawning vfxDespawn;
    public VFXConfig vfxConfig;

    protected override void LoadComponents() {
        base.LoadComponents();
        
        if(vfxPartical == null) vfxPartical = GetComponentInChildren<ParticleSystem>().transform;
        if(vfxMovement == null) vfxMovement = GetComponentInChildren<ObjMovement>();
        if(vfxDespawn == null) vfxDespawn = GetComponentInChildren<ObjDespawning>();
    }

    protected override void OnDisable()
    {
        base.OnDisable();

        ReleaseCallback?.Invoke(gameObject);
    }

    public Action<GameObject> ReleaseCallback { get; set; }
}