using DG.Tweening;
using UnityEngine;

/// <summary>
/// Class define the coin cube's trajectory of rotion by static euler angle. 
/// </summary>
public class CoinCubeRotateByStaticEulerAngleYoyoLoop : ObjRotateByStaticEulerAngleYoyoLoop
{
    protected override void LoadValue()
    {
        rotateSpeed = ((CoinCubeCtrl)GetObjCtrl()).coinCubeConfig.InitialRotateSpeed;
        spawnAngle = ((CoinCubeCtrl)GetObjCtrl()).coinCubeConfig.InitialSpawnAngle;
        targetAngle = ((CoinCubeCtrl)GetObjCtrl()).coinCubeConfig.InitialTargetAngle;

        base.LoadValue();
    }

    protected override object GetObjCtrl()
    {
        return this.transform.parent.GetComponent<CoinCubeCtrl>();
    }

    protected override void SetObjModel()
    {
        if(objModel == null) objModel = ((CoinCubeCtrl)GetObjCtrl()).coinCubeModel;
    }

    protected override Vector3 CalculateTargetAngleToRotate(){   
        var direction = spawnAngle.y > targetAngle.y ? -1 : 1; 
        //The rotation of coin cube only rotates along the y axis 
        //The angle to rotate will gradually change over time base on rotateSpeed
        var _angleToRotate = new Vector3(
            targetAngleToRotate.x,
            targetAngleToRotate.y + direction * rotateSpeed * (1 + DifficultyManager.Instance.GameSpeedRate) * Time.deltaTime,
            targetAngleToRotate.z
        );
        return _angleToRotate;
    }
}