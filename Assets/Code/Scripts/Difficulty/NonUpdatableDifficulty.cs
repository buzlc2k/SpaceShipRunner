using System.Collections;
using UnityEngine;

public abstract class NonUpdatableDifficulty : BaseDifficulty
{
    protected int currentDifficultyLevel;

    protected override void LoadValue()
    {
        base.LoadValue();

        currentDifficultyLevel = 0;
    }

    protected override void Start()
    {
        StartCoroutine(InvokeUpdateGameDifficulty());
    }

    protected abstract IEnumerator InternalTimeBetweenUpdate();

    IEnumerator InvokeUpdateGameDifficulty(){
        while(CheckCanUpdateDifficulty()){
            if(!GameManager.Instance.CurrentGameState.Equals(GameState.Running)) {
                yield return null;
                continue;
            }

            UpdateGameDifficulty();
            yield return StartCoroutine(InternalTimeBetweenUpdate());
        }
    }
}