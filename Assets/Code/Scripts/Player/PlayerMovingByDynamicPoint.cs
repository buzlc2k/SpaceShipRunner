using DG.Tweening;
using UnityEngine;

/// <summary>
/// Derived class extending ObjMoveByDynamicPoint that define Player is moving to a point from input.
/// </summary>
public class PlayerMovingByDynamicPoint : ObjMoveByDynamicPoint
{
    protected override object GetObjCtrl()
    {
        return PlayerCtrl.Instance;
    }

    protected override void SetObjMovementConfig()
    {
        objMovementConfig = PlayerCtrl.Instance.playerConfig.PlayerMovementConfig;
    }

    protected override Vector3 CalculateTargetPosition()
    {
        return InputManager.Instance.MoveInput;
    }
}