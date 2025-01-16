using UnityEngine;
using UnityEngine.UI;

public class StartGameCanvas : BaseCanvas
{ 
    protected override void LoadComponents()
    {
        base.LoadComponents();

        if(RespondingState.Equals(GameState.None)) RespondingState = GameState.StartTransition;
    }
}