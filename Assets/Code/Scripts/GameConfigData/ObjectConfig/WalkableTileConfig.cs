using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/ObjectConfig/WalkableTileConfig")]
public class WalkableTileConfig : ScriptableObject
{
    [Header("Movement")]
    public ObjMoveByStaticPointLoopConfig WalkableTileMovementConfig;
}