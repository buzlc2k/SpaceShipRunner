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
    protected Transform objModel;
    protected ObjRotationConfig objRotationConfig;

    protected virtual void Update() {
        if(CheckCanUpdateRotating()) Rotating();
    }

    protected override void LoadComponents() {
        SetObjModel();
        SetObjRotationConfig();
    }

    protected abstract object GetObjCtrl();

    protected abstract void SetObjRotationConfig();

    protected abstract void SetObjModel();

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
            objRotationConfig.RotateSpeed * (1 + DifficultyManager.Instance.GameSpeedRate) * Time.deltaTime
        );
    }
}