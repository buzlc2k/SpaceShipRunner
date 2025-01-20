using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TabContent : ButMonobehavior
{
    [SerializeField] int tabContentIndex;
    public int TabContentIndex => tabContentIndex;

    protected override void LoadValue()
    {
        base.LoadValue();

        tabContentIndex = transform.GetSiblingIndex();
    }
}