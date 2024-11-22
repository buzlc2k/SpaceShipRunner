using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Base Class của xử lý va chạm trong game
/// </summary>
public abstract class ObjCollision : MonoBehaviour
{
    [Header("CollisionAreaAttribute")]
    [SerializeField] protected float colliderRadius;
    private ObjTagCollision tagOfCollisionableObject;
    private ObjTagCollision tagOfObject; 

    // [Header("CollisionEvent")]
    // protected UnityEvent onEnterCollideCallBack = new();
    // protected UnityEvent onEnterCollisionableAreaCallback = new();

    #region  Properties
    public float ColliderRadius => colliderRadius; 
    public ObjTagCollision TagOfCollisionableObject => tagOfCollisionableObject;
    public ObjTagCollision TagOfObject => tagOfObject; 
    #endregion

    private void Update() {
        CollisionLogicRunning();
    }

    protected abstract object GetObjCtrl();

    /// <summary>
    /// Thực hiện logic kiểm tra va chạm cho đối tượng.
    /// </summary>
    protected virtual void CollisionLogicRunning(){
        if(!CollisionManager.Instance.CheckObjectIsInCollisionableArea(this.transform.parent.gameObject)) StartCoroutine(C_CheckEnterCollisionableAreaNextFrame());
        else CheckCollisionWithOtherObject();
    }

    /// <summary>
    /// Kiểm tra va chạm giữa đối tượng hiện tại và các đối tượng khác trong khu vực va chạm.
    /// Nếu có, gọi OnEnterCollide().
    /// </summary>
    protected virtual void CheckCollisionWithOtherObject(){
        foreach(GameObject obj in CollisionManager.Instance.ObjectsInCollisionableArea){
            //Tính toán có va chạm không dựa vào bound của 2 object.
            bool isWithinCollisionDistance = obj.GetComponentInChildren<ObjCollision>().ColliderRadius + colliderRadius >= Vector3.Distance(obj.transform.position, this.transform.parent.position);
            //Kiểm tra Object va chạm có phải là object được va chạm không.
            bool hasMatchingCollisionTag = obj.GetComponentInChildren<ObjCollision>().TagOfObject == tagOfCollisionableObject; 
            if(!isWithinCollisionDistance || !hasMatchingCollisionTag) continue;
            OnEnterCollide();
        }
    }

    /// <summary>
    /// Coroutine kiểm tra xem đối tượng có vào khu vực va chạm trong frame tiếp theo hay không.
    /// Nếu có, gọi OnEnterCollisionableArea().
    /// </summary>
    protected virtual IEnumerator C_CheckEnterCollisionableAreaNextFrame(){
        yield return null;
        if(CollisionManager.Instance.CheckObjectIsInCollisionableArea(this.transform.parent.gameObject)){
            OnEnterCollisionableArea();
        }
    }

    /// <summary>
    /// Hàm thực hiện logic khi Obj va chạm
    /// </summary>
    protected virtual void OnEnterCollide(){
        //noop
    }

    /// <summary>
    /// Hàm thực hiện logic khi Obj vào vùng có thể va chạm
    /// </summary>
    protected virtual void OnEnterCollisionableArea(){
        //noop
    }
}