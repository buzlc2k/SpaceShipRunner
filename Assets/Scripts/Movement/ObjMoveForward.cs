using UnityEngine;

/// <summary>
/// 
/// </summary>
public class ObjMoveForward : ObjMovement
{
    [Header("ObjMoveForward")]
    [SerializeField] protected Transform moveTarget;

    public virtual void SetMoveTarget(Transform target)
    {
        this.moveTarget = target;
    }

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