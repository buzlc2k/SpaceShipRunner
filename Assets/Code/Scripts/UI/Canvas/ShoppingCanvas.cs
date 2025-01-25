using UnityEngine;
using UnityEngine.UI;

public class ShoppingCanvas : BaseCanvas
{

    protected override void LoadComponents()
    {
        base.LoadComponents();

        if(RespondingState.Equals(GameState.None)) RespondingState = GameState.Shopping;
    }
}