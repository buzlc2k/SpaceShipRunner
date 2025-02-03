public class BuySuccessAudioSpawner : UnLoopAudio_Spawner
{
    protected override void RegisterListener()
    {
        base.RegisterListener();

        Observer.AddListener(EventID.CoinItem_BuySuccess, spawnAudio_Delegate);
        Observer.AddListener(EventID.SpaceShipItem_BuySuccess, spawnAudio_Delegate);
    }

    protected override void UnregisterListener()
    {
        base.UnregisterListener();

        Observer.RemoveListener(EventID.CoinItem_BuySuccess, spawnAudio_Delegate);  
        Observer.RemoveListener(EventID.SpaceShipItem_BuySuccess, spawnAudio_Delegate);      
    }
}