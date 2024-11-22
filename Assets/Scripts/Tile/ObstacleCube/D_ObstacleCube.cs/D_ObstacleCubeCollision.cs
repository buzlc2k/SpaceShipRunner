using System;
using UnityEngine;
using UnityEngine.Events;

public class D_ObstacleCubeCollision : ObstacleCubeCollision
{    
    [Header("D_ObstacleCubeCollision")]

    #region InitializeObstacleCubeMovementAction
    [SerializeField] private int loopToInitializeMovement = 3;
    #endregion

    protected override void OnEnterCollisionableArea()
    {
        base.OnEnterCollisionableArea();
        ((ObstacleCubeMoveByPointYoyoLoop)((ObstacleCubeCtrl)GetObjCtrl()).obstacleCubeMovement).InitializeMovement(loopToInitializeMovement);
    }
}