using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Base class defining the basic rotate logic of an object in the scene.
/// </summary>
public abstract class ObjRotation : ButMonobehavior
{
    [Header("ObjRotation")]
    protected Vector3 targetAngleToRotate; 
    protected float rotateSpeed;
    [SerializeField] protected float rotationThreshold = 0.1f;
    protected Transform objModel;

    protected virtual void Update() {
        Rotating();
    }

    protected override void LoadComponents() {
        SetObjModel();
    }

    protected abstract object GetObjCtrl();

    protected abstract void SetObjModel();

    /// <summary>
    /// Method to set the speed of rotation.
    /// </summary>
    /// <param name="rotateSpeed"> Speed of rotation </param>
    public virtual void SetRotateSpeed(float rotateSpeed){
        if(rotateSpeed < 0) return;
        this.rotateSpeed = rotateSpeed;
    }

    // Method to custom the logic of object's target rotation calculation
    protected virtual Vector3 CalculateTargetAngleToRotate(){
        //noop
        return Vector3.zero;
    }

    /// Direct set the target rotation of object
    protected virtual void SetTargetAngleToRotate(Vector3 targetAngleToRotate)
    {
        this.targetAngleToRotate = targetAngleToRotate;
    }

    // Basic rotate logic of an object in the scene
    protected virtual void Rotating()
    {
        var _targetAngleToRotate = CalculateTargetAngleToRotate();
        SetTargetAngleToRotate(_targetAngleToRotate);
        
        // Sets the rotation of objModel directly to the currentRotationAngle.
        this.objModel.rotation = Quaternion.Euler(this.targetAngleToRotate);
    }
}