using UnityEngine;

/// <summary>
/// Derived class extending ObjRotation allows objects to reset their rotation based on a custom logic.
/// </summary>
public abstract class ObjRotateByStaticEulerAngleLoop : ObjRotation
{
    [Header("ObjRotateByStaticEulerAngleLoop")]
    [SerializeField] protected Vector3 spawnAngle; 
    [SerializeField] protected Vector3 targetAngle;  

    protected override void Rotating()
    {
        base.Rotating();

        ResetRotatingAfterReachTargetAngle();
    }

    protected void ResetRotatingAfterReachTargetAngle(){
        if(CanResetRotating()) ResetingRotating();
    }

    // Check if the object is qualified to reset the rotation
    protected virtual bool CanResetRotating(){
        return Quaternion.Angle(this.objModel.rotation, Quaternion.Euler(targetAngle)) < rotationThreshold;
    }

    // logic when the object is qualified to reset rotation
    protected abstract void ResetingRotating();
}