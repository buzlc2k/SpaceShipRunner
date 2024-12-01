using DG.Tweening;
using UnityEngine;

/// <summary>
/// Derived class extending ObjMoveByDynamicPoint that define Player is moving to a point from input.
/// </summary>
public class PlayerMovingByDynamicPoint : ObjMoveByDynamicPoint
{
    protected override void LoadValue()
    {
        base.LoadValue();
        moveSpeed = ((PlayerCtrl)GetObjCtrl()).playerConfig.InitialMoveSpeed;
    }

    protected override object GetObjCtrl()
    {
        return PlayerCtrl.Instance;
    }

    protected override Vector3 CalculateTargetPosition()
    {
        return InputManager.Instance.MoveInput;
    }
}