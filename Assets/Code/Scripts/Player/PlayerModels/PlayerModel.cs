using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

public class PlayerModel : ButMonobehavior
{
    private Action<KeyValuePair<EventParameterType, object>> loadPlayerModel;

    protected override void SetUpDelegate()
    {
        base.SetUpDelegate();

        loadPlayerModel = (param) => {
            LoadPlayerModel();
        };
    }

    protected override void RegisterListener()
    {
        base.RegisterListener();

        Observer.AddListener(EventID.SetCurrentSpaceShipSuccess, loadPlayerModel);
    }

    protected override void UnregisterListener()
    {
        base.UnregisterListener();

        Observer.RemoveListener(EventID.SetCurrentSpaceShipSuccess, loadPlayerModel);
    }

    private void LoadPlayerModel(){
        if(transform.childCount != 0){
            foreach(Transform spaceShip in transform){
                Destroy(spaceShip.gameObject);
            }
        }
        
        var spaceShipPrefab = ((SpaceShipItemConfig)ObjectsManager.Instance.GetSpaceShipItem(SpaceShipTrackingManager.Instance.CurrentSpaceShipID.ToString()).ItemConfig).SpaceShipPrefab;
        
        Instantiate(spaceShipPrefab, transform.position, transform.rotation, transform);
    }
}
