public class ObstacleCollisionAudioSpawner : UnLoopAudio_Spawner
{
    protected override void RegisterListener()
    {
        base.RegisterListener();
        
        Observer.AddListener(EventID.ObstacleCube_Collide, spawnAudio_Delegate);
    }

    protected override void UnregisterListener()
    {
        base.UnregisterListener();

        Observer.RemoveListener(EventID.ObstacleCube_Collide, spawnAudio_Delegate);
    }
}