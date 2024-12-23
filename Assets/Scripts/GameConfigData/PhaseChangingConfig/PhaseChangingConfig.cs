using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/PhaseChangingConfig")]
public class PhaseChangingConfig : ScriptableObject
{
    [Header("PhaseChangingConfig")]
    public float TimeInterval = 10f;
    public List<ColorConfig> InitialListColor;
}

[Serializable]
public struct ColorConfig
{
    [ColorUsage(true, true)] public Color InitialCurrentColor;
    [ColorUsage(true, true)] public Color InitialTargetColor;
}