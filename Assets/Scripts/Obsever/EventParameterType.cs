/// <summary>
/// Defines types of parameters that can be sent within a triggered event.
/// Enum constants follow the format 'EventID_KeyName' for clarity.
/// </summary>
public enum EventParameterType{
    None = 0,
    ResetWalkableTile_WalkableTileObject,
    AddMoreObstacle_ListObstaclePrefab,
    ObstacleTileSpawned_WalkableTileObjectAndListSpawnPositions,
}