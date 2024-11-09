using UnityEngine;

/// <summary>
/// Derived class extending ObjMovement allows objects to move object follow to target.
/// </summary>
public class ObjMoveForward : ObjMovement
{
    [Header("ObjMoveForward")]
    [SerializeField] protected Transform moveTarget;

    /// <summary>
    /// Set target to move forward.
    /// </summary>
    /// <param name="target">target to move forward.</param>
    public virtual void SetMoveTarget(Transform target)
    {
        this.moveTarget = target;
    }

    /// <summary>
    /// Set targetPos base on moveTarget
    /// </summary>
    protected virtual void GetMovePosition()
    {
        if (this.moveTarget == null) return;

        this.targetPosition = this.moveTarget.position;
    }

    protected override void Moving(){
        GetMovePosition();

        base.Moving();
    }
}