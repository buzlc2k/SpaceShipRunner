using DG.Tweening;
using UnityEngine;

/// <summary>
///  Class define the player's rotion based on move input.
/// </summary>
public class PlayerRotateByMoveInput : ObjRotateByUnstableEulerAngle
{
    protected override void LoadValue()
    {
        base.LoadValue();
        rotateSpeed = ((PlayerCtrl)GetObjCtrl()).playerConfig.InitialRotateSpeed;
    }
    protected override object GetObjCtrl()
    {
        return PlayerCtrl.Instance;
    }

    protected override void SetObjModel()
    {
        if(objModel == null) objModel = ((PlayerCtrl)GetObjCtrl()).playerModel.transform;
    }

    protected override Vector3 CalculateTargetAngleToRotate()
    {
        //Lấy góc quay dựa trên khoảng cách giữa điểm mục tiêu và vị trí player hiện tại
        int directionRotate = InputManager.Instance.MoveInput.x < transform.parent.position.x || 
                          (InputManager.Instance.MoveInput.x == transform.parent.position.x && InputManager.Instance.MoveInput.x < 0) 
                          ? -1 : 1;;
        //Vì Player chỉ quay theo trục X nên chỉ cần tính toán góc quay trục x
        //Cứ đi được 1/35 unit Player quay 10 độ, nếu góc quay quá lớn thì chặn lại tránh bị gimbal lock
        float targetXAngle = 90 + Vector3.Distance(InputManager.Instance.MoveInput, transform.parent.position) * 35 * 10f * directionRotate;
        targetXAngle = Mathf.Clamp(targetXAngle, 60, 120);

        return new Vector3(targetXAngle, 90, 90);
    }
}