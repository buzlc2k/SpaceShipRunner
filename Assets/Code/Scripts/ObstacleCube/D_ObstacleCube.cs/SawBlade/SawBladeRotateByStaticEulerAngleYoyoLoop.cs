using DG.Tweening;
using UnityEngine;

/// <summary>
/// Class define the saw blade's trajectory of rotion by static euler angle. 
/// </summary>
public class SawBladeRotateByStaticEulerAngleYoyoLoop : ObjRotateByStaticEulerAngleRecycleLoop
{
    protected override void LoadValue()
    {
        rotateSpeed = ((SawBladeConfig)((SawBladeCtrl)GetObjCtrl()).obstacleCubeConfig).InitialRotateSpeed;
        spawnAngle = ((SawBladeConfig)((SawBladeCtrl)GetObjCtrl()).obstacleCubeConfig).InitialSpawnAngle;
        targetAngle = ((SawBladeConfig)((SawBladeCtrl)GetObjCtrl()).obstacleCubeConfig).InitialTargetAngle;
        base.LoadValue();
    }

    protected override object GetObjCtrl()
    {
        return transform.parent.GetComponent<SawBladeCtrl>();
    }

    protected override void SetObjModel()
    {
        if(objModel == null) objModel = ((SawBladeCtrl)GetObjCtrl()).obstacleCubeModel;
    }
}