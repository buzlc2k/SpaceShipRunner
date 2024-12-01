using System;
using UnityEngine;
using UnityEngine.Events;

public class D_ObstacleCubeCollision : ObstacleCubeCollision
{    
    [Header("D_ObstacleCubeCollision")]

    #region InitializeObstacleCubeMovementAction
    [SerializeField] private int loopToInitializeMovement = 3;
    #endregion

    protected override void LoadValue()
    {
        base.LoadValue();
        colliderRadius = ((D_ObstacleCubeCtrl)GetObjCtrl()).obstacleCubeConfig.InitialColliderRadius;
        tagOfCollisionableObject = ((D_ObstacleCubeCtrl)GetObjCtrl()).obstacleCubeConfig.InitialTagOfCollisionableObject;
        tagOfObject = ((D_ObstacleCubeCtrl)GetObjCtrl()).obstacleCubeConfig.InitialTagOfObject;
    }

    protected override void OnEnterCollisionableArea()
    {
        base.OnEnterCollisionableArea();
        ((D_ObstacleCubeMoveByPointYoyoLoop)((D_ObstacleCubeCtrl)GetObjCtrl()).obstacleCubeMovement).InitializeMovement(loopToInitializeMovement);
    }
}