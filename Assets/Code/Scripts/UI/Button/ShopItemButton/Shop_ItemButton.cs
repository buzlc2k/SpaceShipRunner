using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Shop_ItemButton : BaseAnimatedButton
{
    protected virtual BaseItem GetItem(){
        return GetComponent<BaseItem>();
    }

    protected override void OnClick()
    {
        InitializeAnimation();
        GetItem().InitializeItemAction();
    }

    protected override void InitializeAnimation()
    {
        buttonSquence = DOTween.Sequence();

        buttonSquence.Append(button.transform.DOScale(1.1f, 0.125f))
                    .Append(button.transform.DOScale(1f, 0.125f));
    }
}