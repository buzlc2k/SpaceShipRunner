using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/AudioConfig/AudioConfig")]

public class AudioConfig : ScriptableObject
{
    public List<AudioClip> AudioClips = new();
    // Random pitch adjustment range.
	public float LowPitchRange = 0.95f;
	public float HighPitchRange = 1.05f;
}