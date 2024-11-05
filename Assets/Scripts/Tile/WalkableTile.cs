using System;
using UnityEngine;

/// <summary>
/// Defines the attributes of a walkable tile.
/// </summary>
public class WalkableTile : Tile
{
    public Vector3 offsetFromPreviousTile;
    public Vector3 offsetToNextTile;
    
}
