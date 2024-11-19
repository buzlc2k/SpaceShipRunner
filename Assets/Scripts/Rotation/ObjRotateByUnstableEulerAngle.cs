using UnityEngine;

/// <summary>
///  Becase of desired angle is unstable, this code uses lerp to make the rotation smooth
/// </summary>
public abstract class ObjRotateByUnstableEulerAngle : ObjRotation
{
    /// <summary>
    /// Method to get the final rotation of object.
    /// </summary>
    protected virtual Vector3 GetTheDesiredAngle(){
        //noop
        return Vector3.zero;
    }

    /// <summary>
    /// Method interpolate smoothly from the current angle to the final angle
    /// </summary>
    /// <param name="_desiredAngle"> Speed of rotation </param>
    protected virtual Vector3 CalculateTheAngleToDesiredAngle(Vector3 _desiredAngle){
        Vector3 _angleToRotate;
        //If the current rotation is close to the target angle (within the rotation threshold), set the target angle directly
        if(Quaternion.Angle(this.objModel.rotation, Quaternion.Euler(_desiredAngle)) < rotationThreshold) _angleToRotate = _desiredAngle;
        //Otherwise, interpolate smoothly from the current angle to the target angle using Quaternion.Lerp
        else _angleToRotate = Quaternion.Lerp(
                objModel.rotation,
                Quaternion.Euler(_desiredAngle),
                rotateSpeed
            ).eulerAngles;
        
        return _angleToRotate;
    } 

    protected override Vector3 CalculateTheCurrentRotationAngle(){
        var _desiredAngle = GetTheDesiredAngle();
        var _angleToRotate = CalculateTheAngleToDesiredAngle(_desiredAngle);
        return _angleToRotate;
    }
}