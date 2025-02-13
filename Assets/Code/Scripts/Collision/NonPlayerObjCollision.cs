using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Base Class của xử lý va chạm trong game
/// </summary>
public abstract class NonPlayerObjCollision : ObjCollision
{
    // Hàm thực hiện logic khi Obj vào vùng có thể va chạm
    public virtual void OnEnterCollisionableArea(){
        //For override
    }
}