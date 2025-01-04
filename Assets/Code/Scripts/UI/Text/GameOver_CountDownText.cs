using System.Collections;
using TMPro;
using UnityEngine;

public class GameOver_CountDownText : BaseText
{
    protected override void UpdateText()
    {
        text.text = ((int)((GameOverCanvas)GetCanvas()).CountDownTime + 1).ToString();
    }
}