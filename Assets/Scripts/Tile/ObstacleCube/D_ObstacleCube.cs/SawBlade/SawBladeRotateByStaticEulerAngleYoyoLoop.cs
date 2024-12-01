using DG.Tweening;
using UnityEngine;

/// <summary>
/// Class define the saw blade's trajectory of rotion by static euler angle. 
/// </summary>
public class SawBladeRotateByStaticEulerAngleYoyoLoop : ObjRotateByStaticEulerAngleYoyoLoop
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
        return this.transform.parent.GetComponent<SawBladeCtrl>();
    }

    protected override void SetObjModel()
    {
        if(objModel == null) objModel = ((SawBladeCtrl)GetObjCtrl()).obstacleCubeModel;
    }

    protected override Vector3 CalculateTargetAngleToRotate(){   
        var direction = spawnAngle.x > targetAngle.x ? -1 : 1; 
        //The rotation of saw blade only rotates along the x axis 
        //The angle to rotate will gradually change over time base on rotateSpeed
        var _angleToRotate = new Vector3(
            targetAngleToRotate.x + direction * rotateSpeed * (1 + DifficultyManager.Instance.GameSpeedRate) * Time.deltaTime,
            targetAngleToRotate.y,
            targetAngleToRotate.z
        );
        return _angleToRotate;
    }
}