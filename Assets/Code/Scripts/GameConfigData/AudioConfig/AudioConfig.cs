using System.Collections.Generic;
using UnityEngine;

public enum AudioID{
    None = 0,
    BackgroundMusic = 1,
    CoinCollision,
    ObstacleCollision,
    ButtonClick,
    BuySuccess,
    CoinDrop,
    ItemClick,
    PointUp,
    TotalCoinCalculated
}

[CreateAssetMenu(menuName = "ScriptableObject/AudioConfig/AudioConfig")]

public class AudioConfig : ScriptableObject
{
    public AudioID AudioID;
    public List<AudioClip> AudioClips = new();
    // Random pitch adjustment range.
	public float LowPitchRange = 0.95f;
	public float HighPitchRange = 1.05f;
}