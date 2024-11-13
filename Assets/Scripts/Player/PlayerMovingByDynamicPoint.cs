using DG.Tweening;
using UnityEngine;

/// <summary>
/// Derived class extending ObjMovement that define Player is moving to a point from input.
/// </summary>
public class PlayerMovingByDynamicPoint : ObjMoveByDynamicPoint
{
    [Header("PlayerMovingByDynamicPoint")]
    [SerializeField] protected float rotateSpeed;

    protected Tween tweenRotateBack;

    protected override void Moving(){
        SetMovePosition(InputManager.Instance.MoveInput);
        RotatePlayerMoving();
        base.Moving();
    }

    /// <summary>
    /// Rotate Player while moving
    /// </summary>
    protected virtual void RotatePlayerMoving(){
        var playerModel = PlayerController.Instance.playerModel.transform;

        if (!InputManager.Instance.IsTouching){
            // Rotate back to default
            tweenRotateBack ??= playerModel.DORotate(new Vector3(90, 90, 90), 0.5f);
            return;
        }

        // Kill active rotation tween and reset it
        tweenRotateBack?.Kill();
        tweenRotateBack = null;

        // Determine direction based on position
        var directionRotate = targetPosition.x < transform.parent.position.x ? -1 : 1;
        
        // 1/20s rotate 7.5 degree
        float targetRotation = 90 + (InputManager.Instance.TouchTime * 20 * 7.5f * directionRotate);
        playerModel.rotation = Quaternion.Lerp(
            playerModel.rotation,
            Quaternion.Euler(targetRotation, 90, 90),
            rotateSpeed
        );
    }
}