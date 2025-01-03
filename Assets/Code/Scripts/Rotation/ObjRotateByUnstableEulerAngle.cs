using UnityEngine;

/// <summary>
///  Becase of desired angle is unstable, this code uses lerp to make the rotation smooth
/// </summary>
public abstract class ObjRotateByUnstableEulerAngle : ObjRotation
{
    protected override Vector3 CalculateTargetAngleToRotate(){
        var _desiredAngle = GetTheFinalAngleToRotate();
        var _angleToRotate = CalculateTheSmoothlyAngleToRotate(_desiredAngle);
        return _angleToRotate;
    }

    // Method to get the final rotation of object.
    protected virtual Vector3 GetTheFinalAngleToRotate(){
        //noop
        return Vector3.zero;
    }

    // Method interpolate smoothly from the current angle to the final angle
    protected virtual Vector3 CalculateTheSmoothlyAngleToRotate(Vector3 finalAngle){
        Vector3 _angleToRotate;
        //If the current rotation is close to the target angle (within the rotation threshold), set the target angle directly
        if(Quaternion.Angle(objModel.rotation, Quaternion.Euler(finalAngle)) < rotationThreshold) _angleToRotate = finalAngle;
        //Otherwise, interpolate smoothly from the current angle to the target angle using Quaternion.Lerp
        else _angleToRotate = Quaternion.Lerp(
                objModel.rotation,
                Quaternion.Euler(finalAngle),
                rotateSpeed * (1 + DifficultyManager.Instance.GameSpeedRate)
            ).eulerAngles;
        
        return _angleToRotate;
    } 
}