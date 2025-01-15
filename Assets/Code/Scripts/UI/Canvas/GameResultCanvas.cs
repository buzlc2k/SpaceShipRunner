using UnityEngine;
using UnityEngine.UI;

public class GameResultCanvas : BaseCanvas
{ 
    protected override void LoadComponents()
    {
        base.LoadComponents();

        if(RespondingState.Equals(GameState.None)) RespondingState = GameState.Result;
    }

    
}