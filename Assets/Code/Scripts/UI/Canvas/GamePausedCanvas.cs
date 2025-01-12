using UnityEngine;
using UnityEngine.UI;

public class GamePausedCanvas : BaseCanvas
{ 
    protected override void LoadComponents()
    {
        base.LoadComponents();

        if(RespondingState.Equals(GameState.None)) RespondingState = GameState.Paused;
    }
}