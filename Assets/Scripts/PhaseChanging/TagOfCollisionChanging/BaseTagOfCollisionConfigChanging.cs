using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class BaseTagOfCollisionConfigChanging : ButMonobehavior
{
    [Header("ObjChangeTagCollision")]
    [SerializeField] protected List<ScriptableObject> objectConfig;
    private Action<KeyValuePair<EventParameterType, object>> changeTagOfConfigCollisionTag;

    protected override void OnEnable()
    {
        base.OnEnable();

        SetUpDelegate();
    }

    protected override void OnDisable()
    {
        base.OnDisable();

        Observer.RemoveListener(EventID.ChangePhase, changeTagOfConfigCollisionTag);
    }

    protected virtual void SetUpDelegate(){
        changeTagOfConfigCollisionTag ??= (param) => {
            ChangeTagOfConfigCollisionTag();
        };

        Observer.AddListener(EventID.ChangePhase, changeTagOfConfigCollisionTag);
    }

    protected abstract void ChangeTagOfConfigCollisionTag();
}