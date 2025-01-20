using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TabCtrl : ButMonobehavior
{
    [SerializeField] TabContentCtrl TabContentCtrl;
    [SerializeField] TabButtonCtrl TabButtonCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();

        if(TabContentCtrl == null) TabContentCtrl = GetComponentInChildren<TabContentCtrl>();
        if(TabButtonCtrl == null) TabButtonCtrl = GetComponentInChildren<TabButtonCtrl>();

        if(TabContentCtrl.TabContents.Count != TabButtonCtrl.TabButtons.Count) Debug.LogWarning("TabButtons Not Equal TabContents");
    }

    protected override void LoadValue()
    {
        base.LoadValue();
    }

    protected override void Start()
    {
        base.Start();

        SwitchTab(0);
    }

    public void SwitchTab(int tabIndex){
        TabContentCtrl.SwitchTabContent(tabIndex);
        TabButtonCtrl.SwitchTabButton(tabIndex);
    }
}