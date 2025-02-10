using UnityEngine;

/// <summary>
/// Despawning .
/// </summary>
public class UnLoopAudioDespawnByTime: ObjDespawnByTime
{
    protected override object GetObjCtrl()
    {
        return transform.parent.GetComponent<UnLoopAudioCtrl>();
    }

    protected override bool CheckCanUpdateDespawning()
    {
        return true;
    }

    protected override void SetObjDespawningConfig()
    {
        objDespawningConfig = ((UnLoopAudioConfig)((UnLoopAudioCtrl)GetObjCtrl()).AudioConfig).AudioDespawningConfig;
    }
}