using System;
using UnityEngine;

/// <summary>
/// Defines the attributes of a tile.
/// </summary>
public class ObstacleTile : MonoBehaviour, IPooled
{
    public void Release()
    {
        gameObject.SetActive(false);
        ReleaseCallback?.Invoke(this.gameObject);
    }

    public Action<GameObject> ReleaseCallback { get; set; }
}

