using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Base class defining the basic movement logic of an object in the scene.
/// </summary>
public abstract class ObjMovement : MonoBehaviour
{
    [Header("ObjMovement")]
    [SerializeField] protected Vector3 targetPosition; 
    [SerializeField] protected float moveSpeed; 

    private void Update() {
        Moving();
    }

    /// <summary>
    /// Method to set the speed of movement.
    /// </summary>
    public virtual void SetMoveSpeed(float _speed){
        this.moveSpeed = _speed;
    }

    /// <summary>
    /// Handle movement logic, moving the object's parent position towards the target position.
    /// </summary>
    protected virtual void Moving(){
        this.transform.parent.position = Vector3.MoveTowards(this.transform.parent.position, this.targetPosition, this.moveSpeed * Time.deltaTime);
    }
}
