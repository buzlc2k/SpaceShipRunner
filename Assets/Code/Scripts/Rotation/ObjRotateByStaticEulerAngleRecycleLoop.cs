using UnityEngine;

/// <summary>
/// Derived class extending ObjRotateByStaticEulerAngleLoop allows objects to reverse the trajectory of rotation.
/// </summary>
public abstract class ObjRotateByStaticEulerAngleRecycleLoop : ObjRotateByStaticEulerAngleLoop
{ 
    
    protected override void InitializResetRotate()
    {
        objModel.rotation = Quaternion.Euler(spawnAngle);
    }
}