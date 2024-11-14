using DG.Tweening;
using UnityEngine;

/// <summary>
/// Derived class extending ObjRotation allows objects to rotate to a Vector3 given. 
/// </summary>
public class PlayerRotatingByEulerAngle : ObjRotationByEulerAngle
{

    protected override void SetObjectModel()
    {
        objModel = PlayerCtrl.Instance.playerModel.transform;
    }

    /// <summary>
    /// Get the target rotation from input
    /// </summary>
    protected override Vector3 CalculateTargetEulerAngle(){
        int directionRotate = InputManager.Instance.MoveInput.x < transform.parent.position.x || 
                          (InputManager.Instance.MoveInput.x == transform.parent.position.x && InputManager.Instance.MoveInput.x < 0) 
                          ? -1 : 1;

        return new Vector3(90 + (Vector3.Distance(InputManager.Instance.MoveInput, this.transform.parent.position) * 32 * 7.5f * directionRotate), 90, 90);
    }

    protected override void Rotating(){

        var _targetRotation = CalculateTargetEulerAngle();
        SetTargetEulerAngle(_targetRotation);

        base.Rotating();
    }
}