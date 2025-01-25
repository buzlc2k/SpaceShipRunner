using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Shop_SpaceShipItemButton : Shop_ItemButton
{
    protected ShopSpaceShipItemButtonLabel currentSpaceShipItemStateButtonLabel;
    [SerializeField] protected List<ShopSpaceShipItemButtonLabel> spaceShipItemStateButtonLabels;

    protected override void LoadComponents()
    {
        base.LoadComponents();

        if(spaceShipItemStateButtonLabels == null || spaceShipItemStateButtonLabels.Count == 0) 
            GetComponentsInChildren<ShopSpaceShipItemButtonLabel>(spaceShipItemStateButtonLabels);
    }

    protected override void OnEnable()
    {
        base.OnEnable();

        StartCoroutine(InitializeUpdateSpaceShipItemButtonLabel());
    }

    IEnumerator InitializeUpdateSpaceShipItemButtonLabel(){
        yield return null;
        SetSpaceShipItemButtonLabel(((SpaceShipItem)GetItem()).CurrentSpaceShipItemState);

        while(gameObject.activeInHierarchy){
            yield return null;
            UpdateSpaceShipItemButtonLabel();
        }

        yield break;
    }

    protected virtual void UpdateSpaceShipItemButtonLabel(){
        if(currentSpaceShipItemStateButtonLabel.RespondingSpaceShipItemState.Equals(((SpaceShipItem)GetItem()).CurrentSpaceShipItemState)) return;
        
        currentSpaceShipItemStateButtonLabel.gameObject.SetActive(false);

        SetSpaceShipItemButtonLabel(((SpaceShipItem)GetItem()).CurrentSpaceShipItemState);
    }

    protected virtual void SetSpaceShipItemButtonLabel(SpaceShipItemState spaceShipItemState){
        foreach(var spaceShipItemStateButtonLabel in spaceShipItemStateButtonLabels)
            if(spaceShipItemStateButtonLabel.RespondingSpaceShipItemState.Equals(spaceShipItemState)){
                currentSpaceShipItemStateButtonLabel = spaceShipItemStateButtonLabel;
                currentSpaceShipItemStateButtonLabel.gameObject.SetActive(true);
            }
    }
}