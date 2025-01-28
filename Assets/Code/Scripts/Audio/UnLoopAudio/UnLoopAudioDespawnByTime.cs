using UnityEngine;

/// <summary>
/// Despawning .
/// </summary>
public class UnLoopAudioDespawnByTime: ObjDespawnByTime
{
    protected override void LoadValue(){
        base.LoadValue();

        timeToDespawn = ((UnLoopAudioCtrl)GetObjCtrl()).CurrentAudioClip.length;
    }

    protected override object GetObjCtrl()
    {
        return transform.parent.GetComponent<UnLoopAudioCtrl>();
    }

    protected override bool CheckCanUpdateDespawning()
    {
        return true;
    }
}