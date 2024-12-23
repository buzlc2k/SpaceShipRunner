using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class PlayerTagOfCollisionConfigChanging : BaseTagOfCollisionConfigChanging
{
    protected override void ChangeTagOfConfigCollisionTag()
    {
        foreach(PlayerConfig playerConfig in objectConfig.Cast<PlayerConfig>())
        {
            (playerConfig.InitialTagOfCollisionableObject, playerConfig.InitialTargetTagOfCollisionableObject) = (playerConfig.InitialTargetTagOfCollisionableObject, playerConfig.InitialTagOfCollisionableObject);
            (playerConfig.InitialTagOfObject, playerConfig.InitialTargetTagOfObject) = (playerConfig.InitialTargetTagOfObject, playerConfig.InitialTagOfObject);
        }
    }
}