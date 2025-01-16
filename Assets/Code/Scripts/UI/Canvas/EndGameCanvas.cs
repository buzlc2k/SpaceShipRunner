using UnityEngine;
using UnityEngine.UI;

public class EndGameCanvas : BaseCanvas
{ 
    protected override void LoadComponents()
    {
        base.LoadComponents();

        if(RespondingState.Equals(GameState.None)) RespondingState = GameState.EndTransition;
    }
}