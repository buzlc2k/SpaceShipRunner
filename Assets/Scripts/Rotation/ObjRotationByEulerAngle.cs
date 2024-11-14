using UnityEngine;

/// <summary>
/// Derived class extending ObjRotation allows objects to rotate to a Vector3 given. 
/// </summary>
public abstract class ObjRotationByEulerAngle : ObjRotation
{
    /// <summary>
    /// Calculate target euler angle base on custom logic
    /// </summary>
    protected virtual Vector3 CalculateTargetEulerAngle(){
        //noop
        return Vector3.zero;
    }

    /// <summary>
    /// Set targetPos base on a euler angle given
    /// </summary>
    public virtual void SetTargetEulerAngle(Vector3 _targetEulerAngle)
    {
        this.targetRotation = _targetEulerAngle;
    }
}