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
            InitializePurchaseItem((BaseItem)param.Value);
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

    public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
    {
        storeController = controller;
        Debug.Log("Initialie IAP Success");
    }

    public void InitializePurchaseItem(BaseItem item){
        switch (item.ItemConfig.Type){
        case ItemType.Coin: 
            InitializePurchaseCoinItem(item);
            break;

        case ItemType.IAP: 
            InitializePurchaseIAPItem(item);
            break;
        }
    }

    private void InitializePurchaseCoinItem(BaseItem item){
        if(item.ItemConfig.Price <= CoinTrackingManager.Instance.TotalCoins)
            item.OnItemPuschaseSuccess();
        else
            item.OnItemPuschaseFailed();
    }

    private void InitializePurchaseIAPItem(BaseItem item){
        storeController.InitiatePurchase(item.ItemConfig.ID.ToString());
    }

    public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs purchaseEvent)
    {
        var itemPurchase = purchaseEvent.purchasedProduct;
        
        ObjectsManager.Instance.GetItem(itemPurchase.definition.id)?.OnItemPuschaseSuccess();
        
        return PurchaseProcessingResult.Complete;
    }

    public void OnPurchaseFailed(Product product, PurchaseFailureDescription failureDescription)
    {
        Debug.Log("Purchase Fail: " + failureDescription.message);
        ObjectsManager.Instance.GetItem(product.definition.id)?.OnItemPuschaseFailed();
    }

    public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
    {
        Debug.Log("Purchase Fail: " + failureReason);
        ObjectsManager.Instance.GetItem(product.definition.id)?.OnItemPuschaseFailed();
    }

    public void OnInitializeFailed(InitializationFailureReason error)
    {
        Debug.Log("Initialize IAP Fail: " + error);
    }

    public void OnInitializeFailed(InitializationFailureReason error, string message)
    {
        Debug.Log("Initialize IAP Fail: " + error + " " + message);
    }
}