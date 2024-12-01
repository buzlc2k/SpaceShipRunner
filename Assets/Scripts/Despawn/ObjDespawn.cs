using UnityEngine;

/// <summary>
/// Abstract base class for managing object despawning logic in Unity.
/// </summary>
public abstract class ObjDespawn : ButMonobehavior
{  
    protected virtual void Update() {
        Despawning();
    }

    protected abstract object GetObjCtrl();

    protected virtual void Despawning(){
        if(CheckCanDespawn()) InitializeDespawn();
    }

    // Checks if the object should despawn
    protected abstract bool CheckCanDespawn();

    // Thực hiện despawn obj
    protected virtual void InitializeDespawn(){
        this.transform.parent.gameObject.SetActive(false);
        //Nếu Obj là Obj trong Pool, gọi ReleaseCallback để trở giải phóng Obj về Pool
        if(GetObjCtrl() is IPooled objPooled) objPooled.ReleaseCallback?.Invoke(this.transform.parent.gameObject);
    }
}