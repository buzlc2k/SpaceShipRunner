public class ButtonClickAudioSpawner : UnLoopAudio_Spawner
{
    protected override void RegisterListener()
    {
        base.RegisterListener();

        Observer.AddListener(EventID.BaseButton_Click, spawnAudio_Delegate);
    }

    protected override void UnregisterListener()
    {
        base.UnregisterListener();

        Observer.RemoveListener(EventID.BaseButton_Click, spawnAudio_Delegate);        
    }
}