using System;
using System.Collections;
public abstract class BaseDifficulty : ButMonobehavior
{
    protected abstract void UpdateGameDifficulty();

    protected abstract bool CheckCanUpdateDifficulty();
}