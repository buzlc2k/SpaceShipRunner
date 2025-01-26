using UnityEngine;
using UnityEngine.UI;

public class ShoppingCanvas : BaseCanvas
{
    public Shop_GetFreeCoinButton shop_GetFreeCoinButton;

    protected override void LoadComponents()
    {
        base.LoadComponents();

        if(RespondingState.Equals(GameState.None)) RespondingState = GameState.Shopping;
        if(shop_GetFreeCoinButton == null) shop_GetFreeCoinButton= GetComponentInChildren<Shop_GetFreeCoinButton>();
    }

    protected override void OnEnable()
    {
        base.OnEnable();

        if(!AdsManager.Instance.RewardedAds.CanShowAds) shop_GetFreeCoinButton.gameObject.SetActive(false);
        else shop_GetFreeCoinButton.gameObject.SetActive(true);
    }
}