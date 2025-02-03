using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TabButtton : BaseButton
{
    [SerializeField] int tabButtonIndex;
    [SerializeField] Button tabButton;
    [SerializeField] Vector3 scaleDiff;

    public int TabButtonIndex => tabButtonIndex;

    protected override void LoadValue()
    {
        base.LoadValue();

        tabButtonIndex = transform.GetSiblingIndex();
        if(tabButton == null)  tabButton = GetComponentInChildren<Button>();
    }

    public TabButtonCtrl GetTabButtonCtrl(){
        return GetComponentInParent<TabButtonCtrl>();
    }

    public void SetButtonInactive(){
        tabButton.transform.localScale -= scaleDiff;
    }

    public void SetTabButtonActive(){
        tabButton.transform.localScale += scaleDiff;
    }

    protected override void OnClick()
    {
        GetTabButtonCtrl().GetTabCtrl().SwitchTab(tabButtonIndex);
    }
}