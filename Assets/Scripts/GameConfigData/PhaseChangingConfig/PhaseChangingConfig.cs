using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/PhaseChangingConfig/PhaseChangingConfig")]
public class PhaseChangingConfig : ScriptableObject
{
    [Header("PhaseChangingConfig")]
    public float TimeInterval = 10f;
    public List<ColorConfig> InitialListColor;
}

[Serializable]
public struct ColorConfig
{
    public Color InitialCurrentColor;
    public Color InitialTargetColor;
}