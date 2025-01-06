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
        if(CheckCanUpdateRotating()) Rotating();
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

    protected virtual bool CheckCanUpdateRotating(){
        return GameManager.Instance.CurrentGameState.Equals(GameState.Running) 
            || GameManager.Instance.CurrentGameState.Equals(GameState.Restarting)
            || GameManager.Instance.CurrentGameState.Equals(GameState.Over);
    }

    // Basic rotate logic of an object in the scene
    protected virtual void Rotating()
    {    
        // Quay tới góc mục tiêu theo rotateSpeed
        objModel.rotation = Quaternion.RotateTowards(
            objModel.rotation,
            Quaternion.Euler(targetAngleToRotate),
            rotateSpeed * (1 + DifficultyManager.Instance.GameSpeedRate) * Time.deltaTime
        );
    }
}