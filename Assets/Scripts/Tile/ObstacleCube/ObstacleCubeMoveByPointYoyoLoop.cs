using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Derived class from ObjMoveByStaticPointYoyoLoop that creates a yoyo movement trajectory loop for Obstacle Cube.
/// </summary>
public class ObstacleCubeMoveByPointYoyoLoop : ObjMoveByStaticPointYoyoLoop
{    
    protected override object GetObjCtrl()
    {
        return this.transform.parent.GetComponent<ObstacleCubeCtrl>();
    }
}