using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Derived class extending ObjCollision that define Player's collide calculating logic.
/// </summary>
public class PlayerCollision : ObjCollision
{    
    protected override object GetObjCtrl()
    {
        return PlayerCtrl.Instance;
    }
}