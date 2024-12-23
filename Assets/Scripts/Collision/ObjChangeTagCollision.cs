using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Base Class của xử lý va chạm trong game
/// </summary>
public abstract class ObjChangeTagCollision : ObjCollision
{
    [Header("ObjChangeTagCollision")]
    protected List<ObjTagCollision> targetTagOfCollisionableObject;
    protected ObjTagCollision targetTagOfOfject;

    private Action<KeyValuePair<EventParameterType, object>> changeTagOfObject;

    protected override void OnEnable()
    {
        base.OnEnable();

        SetUpDelegate();
    }

    protected override void OnDisable()
    {
        base.OnDisable();

        Observer.RemoveListener(EventID.ChangePhase, changeTagOfObject);
    }

    protected virtual void SetUpDelegate(){
        changeTagOfObject ??= (param) => {
            ChangeTagOfObject();
        };

        Observer.AddListener(EventID.ChangePhase, changeTagOfObject);
    }

    protected virtual void ChangeTagOfObject(){
        (tagOfCollisionableObject, targetTagOfCollisionableObject) = (targetTagOfCollisionableObject, tagOfCollisionableObject);
        (tagOfObject, targetTagOfOfject) = (targetTagOfOfject, tagOfObject);
    } 
}