using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Base Class của xử lý va chạm trong game
/// </summary>
public abstract class ObjCollision : ButMonobehavior
{
    [Header("CollisionAreaAttribute")]
    protected bool canCollide = true;
    protected float colliderRadius;
    protected List<ObjTagCollision> tagOfCollisionableObject;
    protected ObjTagCollision tagOfObject;

    #region  Properties
    public float ColliderRadius => colliderRadius; 
    public List<ObjTagCollision> TagOfCollisionableObject => tagOfCollisionableObject;
    public ObjTagCollision TagOfObject => tagOfObject;
    #endregion

    protected override void LoadValue()
    {
        base.LoadValue();

        canCollide = true;
    }

    protected virtual void Update() {
        CollisionLogicRunning();
    }

    protected abstract object GetObjCtrl();

    //Thực hiện logic kiểm tra va chạm cho đối tượng.
    protected virtual void CollisionLogicRunning(){
        if(!CollisionManager.Instance.CheckObjectIsInCollisionableArea(this.transform.parent.gameObject)) StartCoroutine(C_CheckEnterCollisionableAreaNextFrame());
        else CheckCollisionWithOtherObject();
    }

    // Kiểm tra va chạm giữa đối tượng hiện tại và các đối tượng khác trong khu vực va chạm.
    // Nếu có, gọi OnEnterCollide().
    protected virtual void CheckCollisionWithOtherObject(){
        
        foreach(GameObject obj in CollisionManager.Instance.ObjectsInCollisionableArea){
            //Tính toán có va chạm không dựa vào bound của 2 object.
            bool isWithinCollisionDistance = obj.GetComponentInChildren<ObjCollision>().ColliderRadius + colliderRadius >= Vector3.Distance(obj.transform.position, this.transform.parent.position);
            //Kiểm tra Object va chạm có phải là object được va chạm không.
            bool hasMatchingCollisionTag = tagOfCollisionableObject.Contains(obj.GetComponentInChildren<ObjCollision>().TagOfObject); 
            if(!isWithinCollisionDistance || !hasMatchingCollisionTag) continue;
            OnEnterCollide();
            if(!canCollide) break;
        }
    }

    // Coroutine kiểm tra xem đối tượng có vào khu vực va chạm trong frame tiếp theo hay không.
    // Nếu có, gọi OnEnterCollisionableArea().
    protected virtual IEnumerator C_CheckEnterCollisionableAreaNextFrame(){
        yield return new WaitForSeconds(Time.deltaTime); 
        if(CollisionManager.Instance.CheckObjectIsInCollisionableArea(this.transform.parent.gameObject)){
            OnEnterCollisionableArea();
        }
    }

    // Hàm thực hiện logic khi Obj va chạm
    protected virtual void OnEnterCollide(){
        canCollide = false;
        
        CollisionManager.Instance.RegisterToRemoveInCollisionableArea(this.transform.parent.gameObject);
    }

    // Hàm thực hiện logic khi Obj vào vùng có thể va chạm
    protected virtual void OnEnterCollisionableArea(){
        //noop
    }
}