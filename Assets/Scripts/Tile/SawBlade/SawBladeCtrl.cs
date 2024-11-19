using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// Defines the attributes of a tile and control a tile.
/// </summary>
public class SawBladeCtrl : MonoBehaviour
{
    public Transform sawBladeModel;
    public ObjMovement sawBladeMovement;

    private void Awake() {
        sawBladeModel = GetComponentInChildren<MeshRenderer>().transform;
        sawBladeMovement = GetComponentInChildren<ObjMovement>();
    }
}