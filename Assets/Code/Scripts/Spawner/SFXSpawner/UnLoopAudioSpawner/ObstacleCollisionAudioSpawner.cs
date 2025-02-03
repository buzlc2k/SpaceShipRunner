public class ObstacleCollisionAudioSpawner : UnLoopAudio_Spawner
{
    protected override void RegisterListener()
    {
        base.RegisterListener();

        Observer.AddListener(EventID.B_Cube_Collide, spawnAudio_Delegate);
        Observer.AddListener(EventID.W_Cube_Collide, spawnAudio_Delegate);
    }

    protected override void UnregisterListener()
    {
        base.UnregisterListener();

        Observer.RemoveListener(EventID.B_Cube_Collide, spawnAudio_Delegate);
        Observer.RemoveListener(EventID.W_Cube_Collide, spawnAudio_Delegate);
    }
}