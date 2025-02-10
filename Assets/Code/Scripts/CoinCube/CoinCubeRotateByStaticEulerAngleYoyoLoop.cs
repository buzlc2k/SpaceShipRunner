using DG.Tweening;
using UnityEngine;

/// <summary>
/// Class define the coin cube's trajectory of rotion by static euler angle. 
/// </summary>
public class CoinCubeRotateByStaticEulerAngleYoyoLoop : ObjRotateByStaticEulerAngleRecycleLoop
{
    protected override object GetObjCtrl()
    {
        return transform.parent.GetComponent<CoinCubeCtrl>();
    }

    protected override void SetObjRotationConfig()
    {
        objRotationConfig = ((CoinCubeCtrl)GetObjCtrl()).coinCubeConfig.CoinRotationConfig;
        base.SetObjRotationConfig();
    }

    protected override void SetObjModel()
    {
        if(objModel == null) objModel = ((CoinCubeCtrl)GetObjCtrl()).coinCubeModel;
    }
}