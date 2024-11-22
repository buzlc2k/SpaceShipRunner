using UnityEngine;

/// <summary>
/// Derived class extending ObjMovement allows objects to move follow to a point given.
/// </summary>
public abstract class ObjMoveByDynamicPoint : ObjMovement
{
    /// <summary>
    /// Calculate target position which this obj is moving to
    /// </summary>
    protected virtual Vector3 GetTargetPosition(){
        //noop
        return Vector3.zero;
    }

    /// <summary>
    /// Set targetPos base on a point given
    /// </summary>
    public virtual void SetMovePosition(Vector3 _targetPos)
    {
        this.targetPosition = _targetPos;
    }

    protected override void Moving()
    {
        var _targetPos = GetTargetPosition();
        SetMovePosition(_targetPos);
        base.Moving();
    }
}