using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Base class defining the basic rotate logic of an object in the scene.
/// </summary>
public abstract class ObjRotation : MonoBehaviour
{
    [Header("ObjMovement")]
    [SerializeField] protected Vector3 targetRotation; 
    [SerializeField, Range(0, 1)] protected float rotateSpeed;
    protected Transform objModel;
    const float rotationThreshold = 0.1f; 

    private void Start() {
        SetObjectModel();
    }

    private void Update() {
        Rotating();
    }

    /// <summary>
    /// Method to set the object's model to rotate.
    /// </summary>
    protected abstract void SetObjectModel();

    /// <summary>
    /// Method to set the speed of rotation.
    /// </summary>
    public virtual void SetRotateSpeed(float _speed){
        if(_speed < 0 || _speed > 1) return;
        this.rotateSpeed = _speed;
    }

    /// <summary>
    /// Handle rotation logic, rotating the object's model to the target rotation.
    /// </summary>
    protected virtual void Rotating(){
        if(Quaternion.Angle(objModel.rotation, Quaternion.Euler(targetRotation)) < rotationThreshold){
            objModel.rotation = Quaternion.Euler(targetRotation);
            return;
        }
        
        objModel.rotation = Quaternion.Lerp(
            objModel.rotation,
            Quaternion.Euler(targetRotation),
            rotateSpeed
        );
    }
}