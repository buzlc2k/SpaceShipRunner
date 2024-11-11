using UnityEngine;

/// <summary>
/// Derived class extending ObjMovement allows objects to move follow to a point given.
/// </summary>
public abstract class ObjMoveByDynamicPoint : ObjMovement
{
    /// <summary>
    /// Set targetPos base on a point given
    /// </summary>
    public virtual void SetMovePosition(Vector3 _targetPos)
    {
        this.targetPosition = _targetPos;
    }
}