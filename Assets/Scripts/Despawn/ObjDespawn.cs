using UnityEngine;

/// <summary>
/// Abstract base class for managing object despawning logic in Unity.
/// </summary>
public abstract class ObjDespawn : MonoBehaviour
{  
    private void Update() {
        Despawning();
    }

    protected virtual void Despawning(){
        if(CanDespawn()) DespawnObject();
    }

    /// <summary>
    /// Checks if the object should despawn
    /// </summary>
    protected abstract bool CanDespawn();

    /// <summary>
    /// Deactivates the object's parent GameObject, effectively despawning it.
    /// </summary>
    protected virtual void DespawnObject(){
        this.transform.parent.gameObject.SetActive(false);
    }
}