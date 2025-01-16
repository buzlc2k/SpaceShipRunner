using UnityEngine;
using UnityEngine.UI;

public class GameResultCanvas : BaseCanvas
{ 
    public CoinVFX_CollectionPartical CoinVFX_CollectionPartical;

    protected override void LoadComponents()
    {
        base.LoadComponents();

        if(RespondingState.Equals(GameState.None)) RespondingState = GameState.Result;
        if(CoinVFX_CollectionPartical == null) CoinVFX_CollectionPartical = GetComponentInChildren<CoinVFX_CollectionPartical>();
    }
}