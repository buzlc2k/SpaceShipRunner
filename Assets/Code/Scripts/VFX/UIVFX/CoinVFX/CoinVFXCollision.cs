using System;
using System.Collections.Generic;
using UnityEngine;

public class CoinVFXCollision : ButMonobehavior
{
    public List<ParticleSystem.Particle> particlesEnter;

    protected override void LoadComponents() {
        base.LoadComponents();

        particlesEnter = new();
    }

    protected override void Start()
    {
        base.Start();
        
        LoadParticalTriggerCollider();
    }

    public VFXCtrl GetVFXCtrl(){
        return GetComponentInParent<VFXCtrl>();
    }

    private void OnParticleTrigger() {
        int numEnter = GetVFXCtrl().vfxPartical.GetTriggerParticles(ParticleSystemTriggerEventType.Enter, particlesEnter);

        for (int i = 0; i < numEnter; i++)
        {
            ParticleSystem.Particle p = particlesEnter[i];
            p.remainingLifetime = 0;
            particlesEnter[i] = p;
        }

        GetVFXCtrl().vfxPartical.SetTriggerParticles(ParticleSystemTriggerEventType.Enter, particlesEnter);
    }

    public void LoadParticalTriggerCollider(){
        var forceFieldCollider = FindFirstObjectByType<ParticleSystemForceField>()?.GetComponent<Collider2D>();
        if (forceFieldCollider != null)
            GetVFXCtrl().vfxPartical.trigger.AddCollider(forceFieldCollider);
    }
}