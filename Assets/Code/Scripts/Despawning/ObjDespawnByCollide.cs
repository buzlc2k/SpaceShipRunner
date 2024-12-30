using UnityEngine;

/// <summary>
/// Despawning objects based on the collision.
/// </summary>
public abstract class ObjDespawnByCollide : ObjDespawning
{
    [Header("ObjDespawnByCollide")]
    protected bool collided = false;

    protected override void LoadValue()
    {
        base.LoadValue();

        collided = false;
    }

    public virtual void SetObjectCanDespawn(){
        collided = true;
    }

    protected override bool CheckCanDespawn()
    {
        return collided;
    }
}