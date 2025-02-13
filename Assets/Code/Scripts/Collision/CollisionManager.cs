using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Quản lý các đối tượng nằm trong khu vực va chạm xác định trước.
/// </summary>
public class CollisionManager : Singleton<CollisionManager>
{
    
    #region ListObjectsInCollisionableArea
    private HashSet<ObjCollision> CurrentNonPlayerObjectsInCollisionableArea;
    private ObjCollision Player;
    #endregion

    [SerializeField] private CollisionManagerConfig collisionManagerConfig;
    protected Action<KeyValuePair<EventParameterType, object>> removeAllObjectsInCollisionableArea;

    protected override void LoadComponents()
    {
        base.LoadComponents();

        Player = PlayerCtrl.Instance.GetComponentInChildren<ObjCollision>();
        CurrentNonPlayerObjectsInCollisionableArea = new();
    }

    protected override void SetUpDelegate()
    {
        base.SetUpDelegate();

        removeAllObjectsInCollisionableArea ??= param => {
            RemoveAllObjectsInCollisionableArea();
        };
    }

    protected override void RegisterListener()
    {
        base.RegisterListener();

        Observer.AddListener(EventID.EnterGameRestartingState, removeAllObjectsInCollisionableArea);
    }

    protected override void UnregisterListener()
    {
        base.UnregisterListener();

        Observer.RemoveListener(EventID.EnterGameRestartingState, removeAllObjectsInCollisionableArea);
    }

    private void Update() {
        if(!CheckCanUpdateCollision()) return;

        CalculateNonPlayerObjectsInCollisionableArea();
        CollisionLogicRunning();
    }

    protected virtual bool CheckCanUpdateCollision(){
        return GameManager.Instance.CurrentGameState.Equals(GameState.Running) 
            || GameManager.Instance.CurrentGameState.Equals(GameState.Restarting);
    }

    private void CalculateNonPlayerObjectsInCollisionableArea(){
        HashSet<ObjCollision> PreviousNonPlayerObjectsInCollisionableArea = new(CurrentNonPlayerObjectsInCollisionableArea);
        CurrentNonPlayerObjectsInCollisionableArea.Clear();

        List<NonPlayerObjCollision> nonPlayerObjCollisions = new(FindObjectsByType<NonPlayerObjCollision>(FindObjectsSortMode.None));

        foreach(var nonPlayerObjCollision in nonPlayerObjCollisions){
            if(Vector3.Distance(nonPlayerObjCollision.transform.parent.position, collisionManagerConfig.CollisionableAreaCenterPoint) >= collisionManagerConfig.CollisionableAreaRadius) continue;
            
            CurrentNonPlayerObjectsInCollisionableArea.Add(nonPlayerObjCollision);
            if(!PreviousNonPlayerObjectsInCollisionableArea.Contains(nonPlayerObjCollision)) nonPlayerObjCollision.OnEnterCollisionableArea();
        }
    }

    private void CollisionLogicRunning(){
        foreach(NonPlayerObjCollision nonPlayerObjCollision in CurrentNonPlayerObjectsInCollisionableArea){

            bool isWithinCollisionDistance = (Player.ObjCollisionConfig.ColliderRadius + nonPlayerObjCollision.ObjCollisionConfig.ColliderRadius) >= Vector3.Distance(Player.transform.parent.position, nonPlayerObjCollision.transform.parent.position);

            if(!isWithinCollisionDistance) continue;

            nonPlayerObjCollision.OnEnterCollide(Player);
            Player.OnEnterCollide(nonPlayerObjCollision);
        }
    }

    public bool CheckObjectIsInCollisionableArea(NonPlayerObjCollision _nonPlayerObj){
        return CurrentNonPlayerObjectsInCollisionableArea.Contains(_nonPlayerObj);
    }

    private void RemoveAllObjectsInCollisionableArea(){
        CurrentNonPlayerObjectsInCollisionableArea.Clear();
    }
}
