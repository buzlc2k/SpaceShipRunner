using System.Collections;
using UnityEngine;

public abstract class GameResult_BaseAnimatedText : BaseText
{
    protected virtual IEnumerator InitializeAnimation(float totalUnitCount, float animatedTime = 1.1f){
        float targetTime = totalUnitCount * animatedTime;
        float time = 0;

        while (time <= targetTime) {
            time += Time.deltaTime * totalUnitCount ;
            text.text = ((int)(time / animatedTime)).ToString();
            yield return null;
        }
    }
}