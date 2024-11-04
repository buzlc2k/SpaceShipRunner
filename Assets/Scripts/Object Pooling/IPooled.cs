using System;
using UnityEngine;

public interface IPooled
{
    /// <summary>
    /// Giải phóng Object về lại Pool
    /// </summary>
    public void Release();
    Action<GameObject> ReleaseCallback { get; set; }
}
