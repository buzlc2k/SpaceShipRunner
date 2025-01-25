using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/ItemConfig/CoinItemConfig")]
public class ItemConfig : ScriptableObject
{    
    public string Name;
    public ItemType Type;
    public ItemID ID;
    public int Price;
}


public enum ItemType{
    None,
    Coin,
    IAP,
}

public enum ItemID{
    None,
    BasicPrism,
    BabyDooDooDoo,
    ssr_100coins,
    ssr_200coins,
    ssr_500coins
}