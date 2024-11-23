using UnityEngine;

/// <summary>
/// Abstract base class for managing object despawning logic in Unity.
/// </summary>
public abstract class ObjDespawn : MonoBehaviour
{  
    private void Update() {
        Despawning();
    }

    protected abstract object GetObjCtrl();

    protected virtual void Despawning(){
        if(CanDespawn()) DespawnObject();
    }

    // Checks if the object should despawn
    protected abstract bool CanDespawn();

    // Thực hiện despawn obj
    protected virtual void DespawnObject(){
        this.transform.parent.gameObject.SetActive(false);
        //Nếu Obj là Obj trong Pool, gọi ReleaseCallback để trở giải phóng Obj về Pool
        if(GetObjCtrl() is IPooled objPooled) objPooled.ReleaseCallback?.Invoke(this.transform.parent.gameObject);
    }
}