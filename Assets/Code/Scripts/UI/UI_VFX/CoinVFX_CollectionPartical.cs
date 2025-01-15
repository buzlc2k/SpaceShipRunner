using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CoinVFX_CollectionPartical : ButMonobehavior
{
    [SerializeField] private ParticleSystem vfxPartical;
    public List<ParticleSystem.Particle> particlesEnter;

    protected override void LoadComponents() {
        base.LoadComponents();
        
        if(vfxPartical == null) vfxPartical = GetComponent<ParticleSystem>();
        particlesEnter = new();
    }

    private void OnParticleTrigger() {
        int numEnter = vfxPartical.GetTriggerParticles(ParticleSystemTriggerEventType.Enter, particlesEnter);

        for (int i = 0; i < numEnter; i++)
        {
            ParticleSystem.Particle p = particlesEnter[i];
            p.remainingLifetime = 0;
            particlesEnter[i] = p;
        }

        vfxPartical.SetTriggerParticles(ParticleSystemTriggerEventType.Enter, particlesEnter);
    }
}