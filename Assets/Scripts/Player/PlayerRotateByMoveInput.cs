using DG.Tweening;
using UnityEngine;

/// <summary>
///  Class define the player's rotion based on move input.
/// </summary>
public class PlayerRotateByMoveInput : ObjRotateByUnstableEulerAngle
{

    protected override void SetObjectModel()
    {
        objModel = PlayerCtrl.Instance.playerModel.transform;
    }

    protected override Vector3 GetTheDesiredAngle()
    {
        //Get the target angle based on move input
        int directionRotate = InputManager.Instance.MoveInput.x < transform.parent.position.x || 
                          (InputManager.Instance.MoveInput.x == transform.parent.position.x && InputManager.Instance.MoveInput.x < 0) 
                          ? -1 : 1;
        //Move 1/20 unit, then the player will rotate 7.5 degree
        var targetAngle = new Vector3(90 + Vector3.Distance(InputManager.Instance.MoveInput, this.transform.parent.position) * 20 * 7.5f * directionRotate, 90, 90);

        return targetAngle;
    }
}