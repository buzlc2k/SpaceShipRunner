using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObstacleCubeCtrl : ButMonobehavior
{
    [Header("ObstacleCubeCtrl")]
    public Transform obstacleCubeModel;
    public ObjCollision obstacleCubeCollision;
    public ObstacleCubeConfig obstacleCubeConfig;

    protected override void LoadComponents() {
        base.LoadComponents();
        if (obstacleCubeModel == null) obstacleCubeModel = GetComponentInChildren<MeshRenderer>().transform;
        if (obstacleCubeCollision == null) obstacleCubeCollision = GetComponentInChildren<ObjCollision>();
    }

    protected override void ResetValue()
    {
        foreach(Transform child in transform){
            if(!child.gameObject.activeSelf) child.gameObject.SetActive(true);
        }
        
        base.ResetValue();
    }
}