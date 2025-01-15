using System.Collections;
using TMPro;
using UnityEngine;

public class GameOver_CountDownText : BaseText
{
    protected override IEnumerator UpdateText()
    {
        while(true){
            if (!gameObject.activeInHierarchy)
            {
                yield break;
            }

            text.text = ((int)((GameOverCanvas)GetCanvas()).CountDownTime + 1).ToString();
            yield return null;
        }
    }
}