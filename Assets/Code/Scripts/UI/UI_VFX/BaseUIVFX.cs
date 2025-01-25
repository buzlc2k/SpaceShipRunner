using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseUIVFX : ButMonobehavior
{
    [SerializeField] protected ParticleSystem uiVFXPartical;

    protected Action<KeyValuePair<EventParameterType, object>> playUIVFXPartical;

    protected override void LoadComponents() {
        base.LoadComponents();
        
        if(uiVFXPartical == null) uiVFXPartical = GetComponent<ParticleSystem>();
    }

    protected override void SetUpDelegate()
    {
        base.SetUpDelegate();

        playUIVFXPartical = (param) => {
            PlayUIVFXPartical();
        };
    }

    protected virtual BaseCanvas GetCanvas()
    {
        return GetComponentInParent<BaseCanvas>();
    }

    public void PlayUIVFXPartical(){
        uiVFXPartical.Play();
    }
}