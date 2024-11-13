using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;

/// <summary>
/// Class manage all input from player
/// </summary>
public class InputManager : Singleton<InputManager>
{
    
    private void OnEnable() {
        //Enable support for the new Enhanced Touch API and testing with the mouse
        EnhancedTouchSupport.Enable();
        
        //Uncomment the next line if you are using mouse to simulate touch
        TouchSimulation.Enable();
        
        //When the game runs, the player is standing at position (0, 0, 3.5), so the default MoveInput is the same as the player's position
        MoveInput = new(0, 0, 3.5f);
    }

    private void Update() {
        GetIsTouching();
        GetMovePos();
        GetTouchTime();
    }

    /// <summary>
    /// The movement position of the touch
    /// </summary>
    public Vector3 MoveInput;
    private void GetMovePos(){
        if(!IsTouching) return;

        UnityEngine.InputSystem.EnhancedTouch.Touch touch = UnityEngine.InputSystem.EnhancedTouch.Touch.activeTouches[0];
        
        Ray directionOfTouch = CameraController.Instance.MyCamera.ScreenPointToRay(touch.screenPosition);
        
        //layer 6 is TileWay Layer, the area where the player can move
        if (Physics.Raycast(directionOfTouch.origin, directionOfTouch.direction, out RaycastHit hit, Mathf.Infinity, 1 << 6))
        {
            Debug.DrawRay(hit.point, Vector3.up * 2f, Color.cyan, 0.5f);
            MoveInput = new(hit.point.x, 0, 3.5f);
        }
    }

    /// <summary>
    /// Touch time on screen
    /// </summary>
    public float TouchTime = 0;
    private void GetTouchTime(){
        if(!IsTouching) TouchTime = 0;
        else TouchTime += Time.deltaTime;
    }

    /// <summary>
    /// Check is touching
    /// </summary>
    public bool IsTouching = false;
    private void GetIsTouching(){
        if(UnityEngine.InputSystem.EnhancedTouch.Touch.activeFingers.Count == 0) {
            IsTouching = false;
            return;
        }

        UnityEngine.InputSystem.EnhancedTouch.Touch touch = UnityEngine.InputSystem.EnhancedTouch.Touch.activeTouches[0];
            
        if(touch.phase != UnityEngine.InputSystem.TouchPhase.Moved){
            IsTouching = false;
            return;
        }

        IsTouching = true;
    }

}
