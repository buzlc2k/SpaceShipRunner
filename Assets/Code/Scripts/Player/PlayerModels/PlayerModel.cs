using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel : ButMonobehavior
{
    protected override void Start()
    {
        base.Start();

        LoadPlayerModel();
    }

    private void LoadPlayerModel(){
        Instantiate(SpaceShipTrackingManager.Instance.CurrentSpaceShip.SpaceShipPrefab, transform.position, transform.rotation, transform);
    }
}
