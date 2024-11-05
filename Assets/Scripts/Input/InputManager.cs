using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : Singleton<InputManager>
{
    PlayerControls playerInputAction;

    private void Awake() {
        AwakeSingleton();

        playerInputAction = new PlayerControls();
        playerInputAction.Enable();
    }

    public float GetTurnAxisInput(){
        return playerInputAction.Player.Turn.ReadValue<float>();
    }

    public bool GetJumpInput(){
        return playerInputAction.Player.Jump.triggered;
    }

    public bool GetSlideInput(){
        return playerInputAction.Player.Slide.triggered;
    }
}
