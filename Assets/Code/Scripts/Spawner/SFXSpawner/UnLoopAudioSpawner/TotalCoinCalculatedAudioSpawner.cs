public class TotalCoinCalculatedAudioSpawner : UnLoopAudio_Spawner
{
    protected override void RegisterListener()
    {
        base.RegisterListener();

        Observer.AddListener(EventID.TotalCoinCalculated, spawnAudio_Delegate);
    }

    protected override void UnregisterListener()
    {
        base.UnregisterListener();

        Observer.RemoveListener(EventID.TotalCoinCalculated, spawnAudio_Delegate);     
    }
}