using UnityEngine;

/// <summary>
/// Derived class extending ObjRotation allows objects to reset their rotation based on a custom logic.
/// </summary>
public abstract class ObjRotateByStaticEulerAngleLoop : ObjRotation
{
    protected ObjRotateByStaticEulerAngleLoopConfig objRotateByStaticEulerAngleLoopConfig;

    protected override void LoadValue()
    {
        base.LoadValue();
        
        targetAngleToRotate = objRotateByStaticEulerAngleLoopConfig.TargetAngle;
    }

    protected override void SetObjRotationConfig()
    {
        objRotateByStaticEulerAngleLoopConfig = (ObjRotateByStaticEulerAngleLoopConfig)objRotationConfig;
    }

    protected override void Rotating()
    {
        base.Rotating();

        ResetingRotate();
    }

    protected void ResetingRotate(){
        if(CanResetRotating()) InitializResetRotate();
    }

    // Check if the object is qualified to reset the rotation
    protected virtual bool CanResetRotating(){
        return Quaternion.Angle(objModel.rotation, Quaternion.Euler(targetAngleToRotate)) < objRotationConfig.RotationThreshold;
    }

    // logic when the object is qualified to reset rotation
    protected abstract void InitializResetRotate();
}