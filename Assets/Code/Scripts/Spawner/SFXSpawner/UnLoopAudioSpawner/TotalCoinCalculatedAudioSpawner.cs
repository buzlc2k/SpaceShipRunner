using UnityEngine;

public class TotalCoinCalculatedAudioSpawner : UnLoopAudio_Spawner
{
    protected override void SetUpDelegate()
    {
        spawnAudio_Delegate ??= (param) => {
            Invoke(nameof(SpawnAudio), 0.1f);
        };
    }

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