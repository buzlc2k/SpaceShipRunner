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
    protected virtual void SetTargetPosition(Vector3 targetPosition)
    {
        this.targetPosition = targetPosition;
    }

    protected override void Moving()
    {
        var _targetPosition = CalculateTargetPosition();
        SetTargetPosition(_targetPosition);
        base.Moving();
    }
}