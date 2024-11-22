using DG.Tweening;
using UnityEngine;

/// <summary>
///  Class define the player's rotion based on move input.
/// </summary>
public class PlayerRotateByMoveInput : ObjRotateByUnstableEulerAngle
{
    protected override object GetObjCtrl()
    {
        return PlayerCtrl.Instance;
    }

    protected override void SetObjModel()
    {
        objModel = ((PlayerCtrl)GetObjCtrl()).playerModel.transform;
    }

    protected override Vector3 GetTheDesiredAngle()
    {
        //Get the target angle based on move input
        int directionRotate = InputManager.Instance.MoveInput.x < transform.parent.position.x || 
                          (InputManager.Instance.MoveInput.x == transform.parent.position.x && InputManager.Instance.MoveInput.x < 0) 
                          ? -1 : 1;
        //Move 1/35 unit, then the player will rotate 15 degree
        var targetAngle = new Vector3(90 + Vector3.Distance(InputManager.Instance.MoveInput, this.transform.parent.position) * 35 * 15f * directionRotate, 90, 90);

        return targetAngle;
    }
}