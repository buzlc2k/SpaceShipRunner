using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Base Class của xử lý va chạm của các vật thể trong game
/// </summary>
public abstract class ObjCollision : ButMonobehavior
{
    [Header("CollisionAreaAttribute")]
    protected ObjCollisionConfig objCollisionConfig;

    #region  Properties
    public ObjCollisionConfig ObjCollisionConfig => objCollisionConfig;
    #endregion

    protected override void LoadComponents()
    {
        base.LoadComponents();

        SetObjCollisionConfig();
    }

    protected abstract object GetObjCtrl();

    protected abstract void SetObjCollisionConfig();

    // Hàm thực hiện logic khi Obj va chạm
    public abstract void OnEnterCollide(ObjCollision sender);
}