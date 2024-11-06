using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Base class defining the basic movement logic of an object in the scene.
/// This class manages movement from the object's current position to a target position at a specified speed.
/// </summary>
public abstract class ObjMovement : MonoBehaviour
{
    [Header("ObjMovement")]
    [SerializeField] protected Vector3 spawnPosition; // Initial spawn position of the object
    [SerializeField] protected Vector3 targetPosition; // Target position the object should move towards
    [SerializeField] protected float moveSpeed; // Speed at which the object moves

    private void Update() {
        Moving();
    }

    /// <summary>
    /// Method to handle movement logic, moving the object's parent position towards the target position.
    /// </summary>
    protected virtual void Moving(){
        this.transform.parent.position = Vector3.MoveTowards(this.transform.parent.position, targetPosition, moveSpeed * Time.deltaTime);
    }
}
