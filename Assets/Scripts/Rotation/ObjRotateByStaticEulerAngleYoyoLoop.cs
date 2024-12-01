using UnityEngine;

/// <summary>
/// Derived class extending ObjRotateByStaticEulerAngleLoop allows objects to reverse the trajectory of rotation.
/// </summary>
public abstract class ObjRotateByStaticEulerAngleYoyoLoop : ObjRotateByStaticEulerAngleLoop
{ 
    
    protected override void InitializResetRotate()
    {
        //swap value between target angle and spawn angle
        (targetAngle, spawnAngle) = (spawnAngle, targetAngle);
    }
}