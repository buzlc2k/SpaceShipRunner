public class CoinDropAudioSpawner : UnLoopAudio_Spawner
{
    protected override void RegisterListener()
    {
        base.RegisterListener();

        Observer.AddListener(EventID.FinishCalculateTotalCoin, spawnAudio_Delegate);
    }

    protected override void UnregisterListener()
    {
        base.UnregisterListener();

        Observer.RemoveListener(EventID.FinishCalculateTotalCoin, spawnAudio_Delegate);     
    }
}