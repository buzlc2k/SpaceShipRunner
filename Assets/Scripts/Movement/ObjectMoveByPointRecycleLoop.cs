using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Derived class from ObjMoveByPoint that creates a movement loop.
/// When the object gets close enough to the target position, it resets back to the spawn position.
/// </summary>
public class ObjectMoveByPointRecycleLoop : ObjMoveByPointLoop
{
    [Header("ObjectMoveByPointRecycleLoop")]
    [SerializeField] protected Vector3 spawnPosition; // Initial spawn position of the object

    protected override void ResetingMoving(){
        // Reset the object's position back to the spawn position
        this.transform.parent.position = this.spawnPosition;
    }
}
