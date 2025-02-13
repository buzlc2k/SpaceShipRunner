using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;

/// <summary>
/// Class manage all input from player
/// </summary>
public class InputManager : Singleton<InputManager>
{
    protected Action<KeyValuePair<EventParameterType, object>> resetInput;

    protected override void SetUpDelegate()
    {
        base.SetUpDelegate();

        resetInput ??= param => {
            MoveInput = new(0, 0, 3.5f);
            isTouching = false;
        };
    }

    protected override void RegisterListener()
    {
        base.RegisterListener();

        Observer.AddListener(EventID.EnterGameRestartingState, resetInput);
    }

    protected override void UnregisterListener()
    {
        base.UnregisterListener();

        Observer.RemoveListener(EventID.EnterGameRestartingState, resetInput);
    }

    protected override void OnEnable() {
        //Enable support for the new Enhanced Touch API and testing with the mouse
        EnhancedTouchSupport.Enable();
        
        //Uncomment the next line if you are using mouse to simulate touch
        TouchSimulation.Enable();
        base.OnEnable();
    }

    protected override void LoadValue()
    {
        base.LoadValue();
        //When the game runs, the player is standing at position (0, 0, 3.5), so the default MoveInput is the same as the player's position
        MoveInput = new(0, 0, 3.5f);

        isTouching = false;
    }

    private void Update() {
        if(!CheckCanUpdateInput()) return;
        
        CalculateIsTouching();
        CalculateMoveInput();
    }

    protected virtual bool CheckCanUpdateInput(){
        return GameManager.Instance.CurrentGameState.Equals(GameState.Running) 
            || GameManager.Instance.CurrentGameState.Equals(GameState.Restarting);
    }

    private bool isTouching;
    private void CalculateIsTouching(){
        if(UnityEngine.InputSystem.EnhancedTouch.Touch.activeFingers.Count == 0) {
            isTouching = false;
            return;
        }

        UnityEngine.InputSystem.EnhancedTouch.Touch touch = UnityEngine.InputSystem.EnhancedTouch.Touch.activeTouches[0];
            
        if(touch.phase == UnityEngine.InputSystem.TouchPhase.Moved)
            isTouching = true;  
        else
            isTouching = false;  
    }

    /// <summary>
    /// The movement position of the touch
    /// </summary>
    [HideInInspector] public Vector3 MoveInput;
    private void CalculateMoveInput(){
        if(!isTouching) return;

        UnityEngine.InputSystem.EnhancedTouch.Touch touch = UnityEngine.InputSystem.EnhancedTouch.Touch.activeTouches[0];
        
        Ray directionOfTouch = CameraController.Instance.MainCamera.ScreenPointToRay(touch.screenPosition);
        
        //layer 6 is TileWay Layer, the area where the player can move
        if (Physics.Raycast(directionOfTouch.origin, directionOfTouch.direction, out RaycastHit hit, Mathf.Infinity, 1 << 6))
        {
            Debug.DrawRay(hit.point, Vector3.up * 2f, Color.cyan, 0.5f);
            MoveInput = new(hit.point.x, 0, 3.5f);
        }
    }
}
