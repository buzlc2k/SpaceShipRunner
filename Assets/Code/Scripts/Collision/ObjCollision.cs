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
    protected ObjCollisionConfig objCollisionConfig;

    #region  Properties
    public float ColliderRadius => objCollisionConfig.ColliderRadius;
    public ObjTagCollision TagOfObject => objCollisionConfig.TagOfObject;
    #endregion

    protected override void LoadComponents()
    {
        base.LoadComponents();

        SetObjCollisionConfig();
    }

    protected override void LoadValue()
    {
        base.LoadValue();

        canCollide = true;
    }

    protected virtual void Update() {
        if(CheckCanUpdateCollision()) CollisionLogicRunning();
    }

    protected abstract object GetObjCtrl();

    protected abstract void SetObjCollisionConfig();

    protected virtual bool CheckCanUpdateCollision(){
        return GameManager.Instance.CurrentGameState.Equals(GameState.Running) 
            || GameManager.Instance.CurrentGameState.Equals(GameState.Restarting);
    }

    //Thực hiện logic kiểm tra va chạm cho đối tượng.
    protected virtual void CollisionLogicRunning(){
        if(!CollisionManager.Instance.CheckObjectIsInCollisionableArea(transform.parent.gameObject)) StartCoroutine(C_CheckEnterCollisionableAreaNextFrame());
        else CheckCollisionWithOtherObject();
    }

    // Kiểm tra va chạm giữa đối tượng hiện tại và các đối tượng khác trong khu vực va chạm.
    // Nếu có, gọi OnEnterCollide().
    protected virtual void CheckCollisionWithOtherObject(){
        
        foreach(GameObject obj in CollisionManager.Instance.ObjectsInCollisionableArea){
            //Tính toán có va chạm không dựa vào bound của 2 object.
            bool isWithinCollisionDistance = obj.GetComponentInChildren<ObjCollision>().ColliderRadius + objCollisionConfig.ColliderRadius >= Vector3.Distance(obj.transform.position, transform.parent.position);
            //Kiểm tra Object va chạm có phải là object được va chạm không.
            bool hasMatchingCollisionTag = objCollisionConfig.TagOfCollisionableObject.Contains(obj.GetComponentInChildren<ObjCollision>().TagOfObject); 
            if(!isWithinCollisionDistance || !hasMatchingCollisionTag) continue;
            OnEnterCollide();
            if(!canCollide) break;
        }
    }

    // Coroutine kiểm tra xem đối tượng có vào khu vực va chạm trong frame tiếp theo hay không.
    // Nếu có, gọi OnEnterCollisionableArea().
    protected virtual IEnumerator C_CheckEnterCollisionableAreaNextFrame(){
        yield return null; 
        if(CollisionManager.Instance.CheckObjectIsInCollisionableArea(transform.parent.gameObject))
            OnEnterCollisionableArea();
    }

    // Hàm thực hiện logic khi Obj va chạm
    protected virtual void OnEnterCollide(){
        canCollide = false;
        //For override
    }

    // Hàm thực hiện logic khi Obj vào vùng có thể va chạm
    protected virtual void OnEnterCollisionableArea(){
        //For override
    }
}