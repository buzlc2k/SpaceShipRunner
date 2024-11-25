using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Base class defining the basic movement logic of an object in the scene.
/// </summary>
public abstract class ObjMovement : MonoBehaviour
{
    [Header("ObjMovement")]
    protected Vector3 targetPosition = Vector3.zero; 
    [SerializeField] protected float moveSpeed; 

    private void Update() {
        Moving();
    }

    protected abstract object GetObjCtrl();

    /// <summary>
    /// Method to set the speed of movement.
    /// </summary>
    /// <param name="_speed"> speed of movement </param>
    public virtual void SetMoveSpeed(float _speed){
        this.moveSpeed = _speed;
    }

    // Handle movement logic, moving the object's parent position towards the target position.
    protected virtual void Moving(){
        if(this.transform.parent.position.Equals(targetPosition)) return;
        this.transform.parent.position = Vector3.MoveTowards(this.transform.parent.position, 
                                                            this.targetPosition, 
                                                            this.moveSpeed * (1 + DifficultyManager.Instance.GameSpeedRate) * Time.deltaTime);
    }
}
