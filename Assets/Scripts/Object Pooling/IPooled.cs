using System;
using UnityEngine;

public interface IPooled
{
    /// <summary>
    /// Giải phóng Object về lại Pool
    /// </summary>
    Action<GameObject> ReleaseCallback { get; set; }
}
