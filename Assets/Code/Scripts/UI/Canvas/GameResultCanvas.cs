using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class GameResultCanvas : BaseCanvas
{ 
    public Button DoubleCoinButton;
    public Button ReloadGameButton;
    public CoinVFX_CollectionPartical CoinVFX_CollectionPartical;

    protected override void LoadComponents()
    {
        base.LoadComponents();

        if(RespondingState.Equals(GameState.None)) RespondingState = GameState.Result;
        if(CoinVFX_CollectionPartical == null) CoinVFX_CollectionPartical = GetComponentInChildren<CoinVFX_CollectionPartical>();
    }

    public void SetOnlyReloadGameButton(){
        DoubleCoinButton.gameObject.SetActive(false);
        ReloadGameButton.GetComponent<RectTransform>().DOPivotY(140, 0.5f);
    }
}