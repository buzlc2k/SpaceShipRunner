using UnityEngine;

/// <summary>
/// Derived class extending ObjMovement allows objects to move object follow to target.
/// </summary>
public abstract class ObjMoveByDir : ObjMovement
{
    [Header("ObjMoveByDir")]
    protected Vector3 dir = Vector3.back;

    /// <summary>
    /// Set dir to move.
    /// </summary>
    /// <param name="dir">dir to move.</param>
    public virtual void SetDir(Vector3 dir)
    {
        this.dir = dir;
    }

    // Set targetPos base on moveTarget
    protected override void UpdateTargetPosition()
    {
        this.targetPosition = this.transform.parent.position + dir;
    }
}