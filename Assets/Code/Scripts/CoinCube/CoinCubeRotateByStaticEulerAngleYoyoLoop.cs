using DG.Tweening;
using UnityEngine;

/// <summary>
/// Class define the coin cube's trajectory of rotion by static euler angle. 
/// </summary>
public class CoinCubeRotateByStaticEulerAngleYoyoLoop : ObjRotateByStaticEulerAngleRecycleLoop
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
        return transform.parent.GetComponent<CoinCubeCtrl>();
    }

    protected override void SetObjModel()
    {
        if(objModel == null) objModel = ((CoinCubeCtrl)GetObjCtrl()).coinCubeModel;
    }
}