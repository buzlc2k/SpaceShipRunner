using UnityEngine;

/// <summary>
/// 
/// </summary>
public abstract class ObjMoveByTargetTransformWithOffset : ObjMoveByTargetTransform
{
    [Header("ObjMoveByTargetTransformWithOffset")]
    protected Vector3 offsetPoint;

    /// <summary>
    ///  Đặt giá trị offset cho target để object di chuyển theo
    /// </summary>
    /// <param name="offsetPoint">offset thêm vào targetTransform position.</param>
    public virtual void SetOffsetPoint(Vector3 offsetPoint){
        this.offsetPoint = offsetPoint;
    }

    protected override void UpdateTargetPosition()
    {
        if (this.targetTransform == null) return;

        this.targetPosition = this.targetTransform.position + offsetPoint;
    }
}