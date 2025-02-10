using UnityEngine;

/// <summary>
/// Derived class extending ObjMovement allows objects to move object follow to target.
/// </summary>
public abstract class ObjMoveByDir : ObjMovement
{
    [Header("ObjMoveByDir")]
    protected Vector3 dir = Vector3.back;

    // Set targetPos base on moveTarget
    protected override void UpdateTargetPosition()
    {
        targetPosition = transform.parent.position + dir;
    }
}