using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/SpaceShipConfig/SpaceShipConfig")]
public class SpaceShipConfig : ScriptableObject
{
    public SpaceShipID SpaceShipID;
    public GameObject SpaceShipPrefab;
}

public enum SpaceShipID{
    None,
    BasicPrism,
    BabyDooDooDoo,
}
