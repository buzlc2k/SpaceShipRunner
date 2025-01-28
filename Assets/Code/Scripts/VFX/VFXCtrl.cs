using System;
using UnityEngine;

public abstract class VFXCtrl : ButMonobehavior, IPooled
{
    public ParticleSystem vfxPartical;
    public ObjDespawning vfxDespawn;
    public VFXConfig vfxConfig;

    protected override void LoadComponents() {
        base.LoadComponents();
        
        if(vfxPartical == null) vfxPartical = GetComponentInChildren<ParticleSystem>();
        if(vfxDespawn == null) vfxDespawn = GetComponentInChildren<ObjDespawning>();
    }

    protected override void OnDisable()
    {
        base.OnDisable();

        ReleaseCallback?.Invoke(gameObject);
    }

    public Action<GameObject> ReleaseCallback { get; set; }
}