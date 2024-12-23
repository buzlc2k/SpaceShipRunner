using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class ObstaclCubeTagOfCollisionConfigChanging : BaseTagOfCollisionConfigChanging
{
    protected override void ChangeTagOfConfigCollisionTag()
    {
        foreach(ObstacleCubeConfig obstacleCubeConfig in objectConfig.Cast<ObstacleCubeConfig>())
        {
            (obstacleCubeConfig.InitialTagOfCollisionableObject, obstacleCubeConfig.InitialTargetTagOfCollisionableObject) = (obstacleCubeConfig.InitialTargetTagOfCollisionableObject, obstacleCubeConfig.InitialTagOfCollisionableObject);
            (obstacleCubeConfig.InitialTagOfObject, obstacleCubeConfig.InitialTargetTagOfObject) = (obstacleCubeConfig.InitialTargetTagOfObject, obstacleCubeConfig.InitialTagOfObject);
        }
    }
}