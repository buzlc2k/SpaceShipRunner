using UnityEngine;

/// <summary>
/// Derived class extending ObjMovement allows objects to move follow to a point given.
/// </summary>
public abstract class ObjMoveByDynamicPoint : ObjMovement
{
    // Calculate target position which this obj is moving to
    protected virtual Vector3 CalculateTargetPosition(){
        //noop
        return Vector3.zero;
    }

    // Set targetPos base on a point given
    protected override void UpdateTargetPosition()
    {
        this.targetPosition = CalculateTargetPosition();
    }

    protected override void Moving()
    {
        UpdateTargetPosition();
        base.Moving();
    }
}