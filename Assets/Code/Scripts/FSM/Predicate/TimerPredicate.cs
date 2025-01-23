using System.Collections;
using UnityEngine;

public class TimerPredicate: BasePredicate
{
    private readonly float time;
    private bool finishCountDown = false;
    private Coroutine coutDown;

    public TimerPredicate(float time){
        this.time = time;
    }

    public override bool Evaluate()
    {
        coutDown ??= GameManager.Instance.StartCoroutine(CountDown());

        return finishCountDown;
    }

    private IEnumerator CountDown(){
        float timer = time;
        finishCountDown = false;
        
        while(timer >= 0){
            timer -= Time.deltaTime;
            yield return null;
        }
        
        finishCountDown = true;
        yield return null;
        coutDown = null;
    }
}