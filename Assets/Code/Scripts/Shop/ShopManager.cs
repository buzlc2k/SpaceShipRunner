using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.Purchasing.Extension;

public class ShopManager : Singleton<ShopManager>, IDetailedStoreListener
{
    private IStoreController storeController;
    private Action<KeyValuePair<EventParameterType, object>> initializePurchaseItem;

    protected override void Start()
    {
        base.Start();

        SetUpIAPBuilder();
    }

    protected override void SetUpDelegate()
    {
        base.SetUpDelegate();

        initializePurchaseItem ??= (param) => {
            InitializePurchaseItem((ItemConfig)param.Value);
        };
    }

    protected override void RegisterListener()
    {
        base.RegisterListener();

        Observer.AddListener(EventID.WantToBuyItem, initializePurchaseItem);
    }

    protected override void UnregisterListener()
    {
        base.UnregisterListener();

        Observer.RemoveListener(EventID.WantToBuyItem, initializePurchaseItem);
    }

    private void SetUpIAPBuilder(){
        var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());

        //Add product
        foreach(var item in ObjectsManager.Instance.CoinItems)
            builder.AddProduct(item.ItemConfig.ID.ToString(), ProductType.Consumable);

        UnityPurchasing.Initialize(this, builder);
    }

    private void InitializePurchaseItem(ItemConfig itemConfig){
        switch (itemConfig.Type){
        case ItemType.Coin: 
            InitializePurchaseCoinItem(itemConfig);
            break;

        case ItemType.IAP: 
            InitializePurchaseIAPItem(itemConfig);
            break;
        }
    }

    public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
    {
        storeController = controller;
        Debug.Log("Initialie IAP Success");
    }

    public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs purchaseEvent)
    {
        var itemPurchase = purchaseEvent.purchasedProduct;
        
        var coinItemConfig = ObjectsManager.Instance.GetCoinItem(itemPurchase.definition.id);
        
        Observer.PostEvent(EventID.CoinItem_BuySuccess, new KeyValuePair<EventParameterType, object>(EventParameterType.CoinItem_BuySuccess_NumCoinBuyed, ((CoinItemConfig)coinItemConfig.ItemConfig).NumCoinInItem));
        
        return PurchaseProcessingResult.Complete;
    }

    public void OnPurchaseFailed(Product product, PurchaseFailureDescription failureDescription)
    {
        Debug.Log("Purchase Fail: " + failureDescription.message);
    }

    public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
    {
        Debug.Log("Purchase Fail: " + failureReason);
    }

    public void OnInitializeFailed(InitializationFailureReason error)
    {
        Debug.Log("Initialize IAP Fail: " + error);
    }

    public void OnInitializeFailed(InitializationFailureReason error, string message)
    {
        Debug.Log("Initialize IAP Fail: " + error + " " + message);
    }

    private void InitializePurchaseIAPItem(ItemConfig itemConfig){
        storeController.InitiatePurchase(itemConfig.ID.ToString());
    }

    private void InitializePurchaseCoinItem(ItemConfig itemConfig){
        if(itemConfig.Price <= CoinTrackingManager.Instance.TotalCoins){
            Observer.PostEvent(EventID.SpaceShipItem_BuySuccess, new KeyValuePair<EventParameterType, object>(EventParameterType.SpaceShipItem_BuySuccess_SpaceShipConfig, itemConfig.ID));
            Observer.PostEvent(EventID.LoadCoinsData, new KeyValuePair<EventParameterType, object>(EventParameterType.LoadCoinsData_TotalCoins, -itemConfig.Price));
        }
        else{
            Debug.Log("Not enough coins");
        }
    }
}