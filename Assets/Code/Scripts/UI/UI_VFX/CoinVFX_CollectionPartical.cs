using System;
using System.Collections.Generic;
using UnityEngine;

public class CoinVFX_CollectionPartical : BaseUIVFX
{
    public List<ParticleSystem.Particle> particlesEnter;

    protected override void LoadComponents() {
        base.LoadComponents();

        particlesEnter = new();
    }

    private void OnParticleTrigger() {
        int numEnter = uiVFXPartical.GetTriggerParticles(ParticleSystemTriggerEventType.Enter, particlesEnter);

        for (int i = 0; i < numEnter; i++)
        {
            ParticleSystem.Particle p = particlesEnter[i];
            p.remainingLifetime = 0;
            particlesEnter[i] = p;
        }

        uiVFXPartical.SetTriggerParticles(ParticleSystemTriggerEventType.Enter, particlesEnter);
    }
}