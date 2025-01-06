using UnityEngine;

/// <summary>
///  Becase of desired angle is unstable, this code uses lerp to make the rotation smooth
/// </summary>
public abstract class ObjRotateByUnstableEulerAngle : ObjRotation
{
    // Method to custom the logic of object's target rotation calculation
    protected abstract Vector3 CalculateTargetAngleToRotate();

    /// Direct set the target rotation of object
    protected virtual void SetTargetAngleToRotate(Vector3 targetAngleToRotate)
    {
        this.targetAngleToRotate = targetAngleToRotate;
    }

    protected override void Rotating()
    {
        var _targetAngleToRotate = CalculateTargetAngleToRotate();
        SetTargetAngleToRotate(_targetAngleToRotate);
        
        if(Quaternion.Angle(objModel.rotation, Quaternion.Euler(targetAngleToRotate)) < rotationThreshold){
            objModel.rotation = Quaternion.Lerp(
                objModel.rotation,
                Quaternion.Euler(targetAngleToRotate),
                0.1f
            );   
            return;
        }
                 

        base.Rotating();
    }
}