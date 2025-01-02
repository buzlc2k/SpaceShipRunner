using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Quản lý các đối tượng nằm trong khu vực va chạm xác định trước.
/// </summary>
public class CollisionManager : Singleton<CollisionManager>
{
    #region CollisionableAreaAttribute
    private readonly Vector3 collisionableAreaCenterPoint = new(0, 0, 3.5f);
    private readonly float collisionableAreaRadius = 7.5f;
    #endregion
    
    #region ListObjectsInCollisionableArea
    public HashSet<GameObject> ObjectsInCollisionableArea = new();
    #endregion
    
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

    public void RegisterToRemoveInCollisionableArea(GameObject _gameObject){
        StartCoroutine(RemoveObjectInCollisionableArea(_gameObject));
    }

    private IEnumerator RemoveObjectInCollisionableArea(GameObject _gameObject){
        yield return null; 

        ObjectsInCollisionableArea.Remove(_gameObject);
    }
}
