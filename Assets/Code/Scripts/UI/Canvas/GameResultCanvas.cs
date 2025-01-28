using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class GameResultCanvas : BaseCanvas
{ 
    public Button DoubleCoinButton;
    public Button ReloadGameButton;

    protected override void LoadComponents()
    {
        base.LoadComponents();

        if(RespondingState.Equals(GameState.None)) RespondingState = GameState.Result;
    }

    protected override void OnEnable()
    {
        base.OnEnable();

        if(!AdsManager.Instance.RewardedAds.CanShowAds) Invoke(nameof(SetOnlyReloadGameButton), 11.47f);
    }

    public void SetOnlyReloadGameButton(){
        DoubleCoinButton.gameObject.SetActive(false);
        ReloadGameButton.GetComponent<RectTransform>().DOPivotY(140, 0.5f);
    }
}