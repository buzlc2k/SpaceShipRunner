using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TabContentCtrl : ButMonobehavior
{
    public List<TabContent> TabContents;
    TabContent currentTabContent;

    protected override void LoadComponents()
    {
        base.LoadComponents();

        currentTabContent = null;

        if(TabContents.Count == 0){
            foreach (Transform child in transform){
                if(child.TryGetComponent<TabContent>(out var tabContent)) TabContents.Add(tabContent);
            }
        }
    }

    public TabCtrl GetTabCtrl(){
        return GetComponentInParent<TabCtrl>();
    }

    public void SwitchTabContent(int tabIndex){
        if(currentTabContent != null) currentTabContent.gameObject.SetActive(false);

        foreach (TabContent tabContent in TabContents){
            if(tabIndex == tabContent.TabContentIndex) {
                currentTabContent = tabContent;
            }
            
        }
        currentTabContent.gameObject.SetActive(true);
    }
}