using DG.Tweening;
using UnityEngine;

/// <summary>
/// Class define the saw blade's trajectory of rotion by static euler angle. 
/// </summary>
public class SawBladeRotateByStaticEulerAngleYoyoLoop : ObjRotateByStaticEulerAngleYoyoLoop
{
    protected override object GetObjCtrl()
    {
        return this.transform.parent.GetComponent<SawBladeCtrl>();
    }

    protected override void SetObjModel()
    {
        objModel = ((SawBladeCtrl)GetObjCtrl()).obstacleCubeModel;
    }

    protected override Vector3 CalculateTheCurrentRotationAngle(){   
        var direction = spawnAngle.x > targetAngle.x ? -1 : 1; 
        //The rotation of saw blade only rotates along the x axis 
        //The angle to rotate will gradually change over time base on rotateSpeed
        var _angleToRotate = new Vector3(
            currentRotationAngle.x + direction * rotateSpeed * Time.deltaTime,
            currentRotationAngle.y,
            currentRotationAngle.z
        );
        return _angleToRotate;
    }
}