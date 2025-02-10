using DG.Tweening;
using UnityEngine;

/// <summary>
/// Class define the saw blade's trajectory of rotion by static euler angle. 
/// </summary>
public class SawBladeRotateByStaticEulerAngleYoyoLoop : ObjRotateByStaticEulerAngleRecycleLoop
{
    protected override object GetObjCtrl()
    {
        return transform.parent.GetComponent<SawBladeCtrl>();
    }

    protected override void SetObjRotationConfig()
    {
        objRotationConfig = ((SawBladeConfig)((SawBladeCtrl)GetObjCtrl()).obstacleCubeConfig).SawBladeRotationConfig;
        base.SetObjRotationConfig();
    }

    protected override void SetObjModel()
    {
        if(objModel == null) objModel = ((SawBladeCtrl)GetObjCtrl()).obstacleCubeModel;
    }
}