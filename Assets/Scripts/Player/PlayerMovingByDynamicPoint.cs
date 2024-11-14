using DG.Tweening;
using UnityEngine;

/// <summary>
/// Derived class extending ObjMovement that define Player is moving to a point from input.
/// </summary>
public class PlayerMovingByDynamicPoint : ObjMoveByDynamicPoint
{
    protected override void Moving(){
        SetMovePosition(InputManager.Instance.MoveInput);
        // RotatePlayerMoving();
        base.Moving();
    }
}