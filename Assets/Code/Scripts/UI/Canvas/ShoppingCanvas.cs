using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShoppingCanvas : BaseCanvas
{
    public Shop_GetFreeCoinButton shop_GetFreeCoinButton;
    [SerializeField] Animator canvasAnimator;
    protected Action<KeyValuePair<EventParameterType, object>> initializeShakeCanvas;

    protected override void LoadComponents()
    {
        base.LoadComponents();

        if(RespondingState.Equals(GameState.None)) RespondingState = GameState.Shopping;
        if(shop_GetFreeCoinButton == null) shop_GetFreeCoinButton= GetComponentInChildren<Shop_GetFreeCoinButton>();
        if(canvasAnimator == null) canvasAnimator = GetComponent<Animator>();
    }

    protected override void SetUpDelegate(){
        initializeShakeCanvas ??= param => {
            InitializeShakeCanvas();
        };
    }

    protected override void RegisterListener()
    {
        base.RegisterListener();

        Observer.AddListener(EventID.Item_BuyFailed, initializeShakeCanvas);
    }

    protected override void UnregisterListener()
    {
        base.UnregisterListener();

        Observer.RemoveListener(EventID.Item_BuyFailed, initializeShakeCanvas);
    }

    protected override void OnEnable()
    {
        base.OnEnable();

        if(!AdsManager.Instance.RewardedAds.CanShowAds) shop_GetFreeCoinButton.gameObject.SetActive(false);
        else shop_GetFreeCoinButton.gameObject.SetActive(true);
    }

    private void InitializeShakeCanvas(){
        canvasAnimator.SetTrigger("BuyFailed");
    }
}