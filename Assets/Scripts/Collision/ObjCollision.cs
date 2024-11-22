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

    [Header("CollisionEvent")]
    private UnityEvent onEnterCollideCallBack = new();
    private UnityEvent onEnterCollisionableAreaCallback = new();
    [SerializeField] private List<EventAction> onEnterCollideCallBackActions;
    [SerializeField] private List<EventAction>  onEnterCollisionableAreaCallbackActions;

    #region  Properties
    public float ColliderRadius => colliderRadius; 
    public ObjTagCollision TagOfCollisionableObject => tagOfCollisionableObject;
    public ObjTagCollision TagOfObject => tagOfObject; 
    #endregion

    private void Update() {
        CollisionLogicRunning();
    }

    private void OnEnable() {
        RegisterActions(onEnterCollisionableAreaCallbackActions, onEnterCollisionableAreaCallback);
        RegisterActions(onEnterCollideCallBackActions, onEnterCollideCallBack);
    }

    private void Start() {
        GetObjCtrl();
    }

    protected abstract object GetObjCtrl();

    private void OnDisable() {
        onEnterCollideCallBack?.RemoveAllListeners();
        onEnterCollisionableAreaCallback?.RemoveAllListeners();
    }

    private void RegisterActions(List<EventAction> actions, UnityEvent unityEvent)
    {
        foreach (var action in actions)
        {
            action?.RegisterListener(unityEvent);
        }
    }

    /// <summary>
    /// Thực hiện logic kiểm tra va chạm cho đối tượng.
    /// </summary>
    protected virtual void CollisionLogicRunning(){
        if(!CollisionManager.Instance.CheckObjectIsInCollisionableArea(this.transform.parent.gameObject)) StartCoroutine(C_CheckEnterCollisionableAreaNextFrame());
        else CheckCollisionWithOtherObject();
    }

    /// <summary>
    /// Kiểm tra va chạm giữa đối tượng hiện tại và các đối tượng khác trong khu vực va chạm.
    /// </summary>
    protected virtual void CheckCollisionWithOtherObject(){
        foreach(GameObject obj in CollisionManager.Instance.ObjectsInCollisionableArea){
            //Tính toán có va chạm không dựa vào bound của 2 object.
            bool isWithinCollisionDistance = obj.GetComponentInChildren<ObjCollision>().ColliderRadius + colliderRadius >= Vector3.Distance(obj.transform.position, this.transform.parent.position);
            //Kiểm tra Object va chạm có phải là object được va chạm không.
            bool hasMatchingCollisionTag = obj.GetComponentInChildren<ObjCollision>().TagOfObject == tagOfCollisionableObject; 
            if(!isWithinCollisionDistance || !hasMatchingCollisionTag) continue;
            onEnterCollideCallBack?.Invoke();
        }
    }

    /// <summary>
    /// Coroutine kiểm tra xem đối tượng có vào khu vực va chạm trong frame tiếp theo hay không.
    /// Nếu có, gọi Event onEnterCollisionableAreaCallback.
    /// </summary>
    protected virtual IEnumerator C_CheckEnterCollisionableAreaNextFrame(){
        yield return null;
        if(CollisionManager.Instance.CheckObjectIsInCollisionableArea(this.transform.parent.gameObject)){
            onEnterCollisionableAreaCallback?.Invoke();
        }
    }
}