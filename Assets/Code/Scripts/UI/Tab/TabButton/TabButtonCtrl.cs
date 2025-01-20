using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TabButtonCtrl : ButMonobehavior
{
    public List<TabButtton> TabButtons;
    TabButtton currentTabButtton;

    protected override void LoadComponents()
    {
        base.LoadComponents();

        currentTabButtton = null;

        if(TabButtons.Count == 0){
            foreach (Transform child in transform){
                if(child.TryGetComponent<TabButtton>(out var tabButtton)) TabButtons.Add(tabButtton);
            }
        }
    }

    public TabCtrl GetTabCtrl(){
        return GetComponentInParent<TabCtrl>();
    }

    public void SwitchTabButton(int tabIndex){
        if(currentTabButtton != null) currentTabButtton.SetButtonInactive();

        foreach (TabButtton tabButtton in TabButtons){
            if(tabIndex == tabButtton.TabButtonIndex) currentTabButtton = tabButtton;
        }
        currentTabButtton.SetTabButtonActive();
    }
}