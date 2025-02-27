using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectsManager : Singleton<ObjectsManager>
{
    public List<CoinItem> CoinItems;
    public List<SpaceShipItem> SpaceShipItems;

    protected Action<KeyValuePair<EventParameterType, object>> resetObjectsInScene;

    protected override void SetUpDelegate()
    {
        base.SetUpDelegate();

        resetObjectsInScene ??= param => {
            SetActivePlayer(true);
            SetActiveCoins(false);
            SetActiveObstacleTiles(false);
        };
    }

    protected override void RegisterListener()
    {
        base.RegisterListener();

        Observer.AddListener(EventID.EnterGameRestartingState, resetObjectsInScene);
    }

    protected override void UnregisterListener()
    {
        base.UnregisterListener();

        Observer.RemoveListener(EventID.EnterGameRestartingState, resetObjectsInScene);
    }

    private void SetActivePlayer(bool enable){
        PlayerCtrl.Instance.gameObject.SetActive(enable);
    }

    private void SetActiveCoins(bool enable, bool includeInactiveObjects = false)
    {
        var coinsInScene = (includeInactiveObjects ? Resources.FindObjectsOfTypeAll<CoinCtrl>() : FindObjectsByType<CoinCtrl>(FindObjectsSortMode.None))
                            .Select(coinCtrl => coinCtrl.gameObject)
                            .ToArray();

        foreach (var coin in coinsInScene)
        {
            coin.SetActive(enable);
        }
    }

    private void SetActiveObstacleTiles(bool enable, bool includeInactiveObjects = false)
    {
        var obstacleTilesInScene = (includeInactiveObjects ? Resources.FindObjectsOfTypeAll<ObstacleTileCtrl>() : FindObjectsByType<ObstacleTileCtrl>(FindObjectsSortMode.None))
                            .Select(obstacleTileCtrl => obstacleTileCtrl.gameObject)
                            .ToArray();

        foreach (var obstacleTile in obstacleTilesInScene)
        {
            obstacleTile.SetActive(enable);
        }
    }

    public BaseItem GetItem(string itemID){
        foreach(var coinItem in CoinItems)
            if(coinItem.ItemConfig.ID.ToString().Equals(itemID))
                return coinItem;

        foreach(var spaceShipItem in SpaceShipItems)
            if(spaceShipItem.ItemConfig.ID.ToString().Equals(itemID))
                return spaceShipItem;
        
        return null;
    }
}