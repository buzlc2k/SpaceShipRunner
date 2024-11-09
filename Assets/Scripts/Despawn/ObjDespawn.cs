using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// </summary>
public abstract class ObjDespawn : MonoBehaviour
{
    //[Header("ObjDespawn")]
    
    

    private void Update() {
        Despawning();
    }

    /// <summary>
    /// 
    /// </summary>
    protected virtual void Despawning(){
        if(CanDespawn()) this.transform.parent.gameObject.SetActive(false);
    }

    protected abstract bool CanDespawn();
}