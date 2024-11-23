using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Base class defining the basic rotate logic of an object in the scene.
/// </summary>
public abstract class ObjRotation : MonoBehaviour
{
    [Header("ObjRotation")]
    [SerializeField] protected Vector3 currentRotationAngle; 
    [SerializeField] protected float rotateSpeed;
    [SerializeField] protected float rotationThreshold = 0.1f;
    protected Transform objModel;

    private void Update() {
        Rotating();
    }

    private void Start() {
        SetObjModel();
    }

    protected abstract object GetObjCtrl();

    protected abstract void SetObjModel();

    /// <summary>
    /// Method to set the speed of rotation.
    /// </summary>
    /// <param name="_speed"> Speed of rotation </param>
    public virtual void SetRotateSpeed(float _speed){
        if(_speed < 0 || _speed > 1) return;
        this.rotateSpeed = _speed;
    }

    // Method to custom the logic of object's curent rotation calculation
    protected virtual Vector3 CalculateTheCurrentRotationAngle(){
        //noop
        return Vector3.zero;
    }

    /// <summary>
    /// Direct set the rotation of object
    /// </summary>
    /// <param name="_currentRotationAngle"> The angle which is the rotation of object </param>
    public virtual void SetAngleToRotate(Vector3 _currentRotationAngle)
    {
        this.currentRotationAngle = _currentRotationAngle;
    }

    // Basic rotate logic of an object in the scene
    protected virtual void Rotating()
    {
        var currentRotationAngle = CalculateTheCurrentRotationAngle();
        SetAngleToRotate(currentRotationAngle);
        
        // Sets the rotation of objModel directly to the currentRotationAngle.
        this.objModel.rotation = Quaternion.Euler(this.currentRotationAngle);
    }
}