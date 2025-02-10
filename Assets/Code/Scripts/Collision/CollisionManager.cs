using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Quản lý các đối tượng nằm trong khu vực va chạm xác định trước.
/// </summary>
public class CollisionManager : Singleton<CollisionManager>
{
    
    #region ListObjectsInCollisionableArea
    public HashSet<GameObject> ObjectsInCollisionableArea = new();
    #endregion

    [SerializeField] private CollisionManagerConfig collisionManagerConfig;
    protected Action<KeyValuePair<EventParameterType, object>> removeAllObjectsInCollisionableArea;

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
        GetObjectsInCollisionableArea();
    }

    public void GetObjectsInCollisionableArea(){
        List<ObjCollision> objCollisions = new(FindObjectsByType<ObjCollision>(FindObjectsSortMode.None));

        ObjectsInCollisionableArea.Clear();

        foreach(var objCollision in objCollisions){
            if(Vector3.Distance(objCollision.transform.parent.position, collisionManagerConfig.CollisionableAreaCenterPoint) < collisionManagerConfig.CollisionableAreaRadius)
                ObjectsInCollisionableArea.Add(objCollision.transform.parent.gameObject);
            else continue;
        }
    }
    
    /// <summary>
    /// Kiểm tra xem một đối tượng có nằm trong khu vực va chạm hay không.
    /// </summary>
    /// <param name="_gameObject">Đối tượng cần kiểm tra.</param>
    public bool CheckObjectIsInCollisionableArea(GameObject _gameObject){
        return ObjectsInCollisionableArea.Contains(_gameObject);
    }

    private void RemoveAllObjectsInCollisionableArea(){
        ObjectsInCollisionableArea.Clear();
    }
}
