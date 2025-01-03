using UnityEngine;

/// <summary>
/// Abstract base class for managing object despawning logic in Unity.
/// </summary>
public abstract class ObjDespawning : ButMonobehavior
{  
    protected virtual void Update() {
        if(CheckCanUpdateDespawning()) Despawning();
    }

    protected abstract object GetObjCtrl();

    protected virtual bool CheckCanUpdateDespawning(){
        return GameManager.Instance.CurrentGameState.Equals(GameState.Running) 
            || GameManager.Instance.CurrentGameState.Equals(GameState.Restarting)
            || GameManager.Instance.CurrentGameState.Equals(GameState.Over);
    }

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