using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TabButtton : ButMonobehavior
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

    protected override void RegisterListener()
    {
        base.RegisterListener();

        tabButton.onClick.AddListener(OnClick);
    }

    protected override void UnregisterListener()
    {
        base.UnregisterListener();

        tabButton.onClick.RemoveListener(OnClick);
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

    public void OnClick(){
        GetTabButtonCtrl().GetTabCtrl().SwitchTab(tabButtonIndex);
    }
}