using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Quản lý các đối tượng nằm trong khu vực va chạm xác định trước.
/// </summary>
public class CollisionManager : Singleton<CollisionManager>
{
    #region CollisionableAreaAttribute
    private Vector3 collisionableAreaCenterPoint;
    private float collisionableAreaRadius;
    #endregion
    
    #region ListObjectsInCollisionableArea
    public HashSet<GameObject> ObjectsInCollisionableArea = new();
    #endregion

    [SerializeField] private CollisionManagerConfig collisionManagerConfig;
    protected Action<KeyValuePair<EventParameterType, object>> removeAllObjectsInCollisionableArea;

    protected override void LoadValue()
    {
        base.LoadValue();

        collisionableAreaCenterPoint = collisionManagerConfig.InitialCollisionableAreaCenterPoint;
        collisionableAreaRadius = collisionManagerConfig.InitialCollisionableAreaRadius;
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
    
    /// <summary>
    /// Kiểm tra xem một đối tượng có nằm trong khu vực va chạm hay không.
    /// </summary>
    /// <param name="_gameObject">Đối tượng cần kiểm tra.</param>
    public bool CheckObjectIsInCollisionableArea(GameObject _gameObject){
        float distanceToCenterPoint = Vector3.Distance(_gameObject.transform.position, collisionableAreaCenterPoint);
        bool isWithinArea = distanceToCenterPoint < collisionableAreaRadius;

        if (ObjectsInCollisionableArea.Contains(_gameObject))
        {
            if (isWithinArea) return true;
            ObjectsInCollisionableArea.Remove(_gameObject);
            return false;
        }
        else
        {
            if (isWithinArea) ObjectsInCollisionableArea.Add(_gameObject);
            return isWithinArea;
        }
    }

    /// <summary>
    /// Đăng ký 1 Object sẽ bị loại bỏ trong Collisionable Area trong frame sau.
    /// </summary>
    /// <param name="_gameObject">Đối tượng cần loại bỏ.</param>
    public void RegisterToRemoveInCollisionableArea(GameObject _gameObject){
        StartCoroutine(RemoveObjectInCollisionableArea(_gameObject));
    }

    private IEnumerator RemoveObjectInCollisionableArea(GameObject _gameObject){
        yield return null; 
        ObjectsInCollisionableArea.Remove(_gameObject);
    }

    private void RemoveAllObjectsInCollisionableArea(){
        ObjectsInCollisionableArea.Clear();
    }
}
