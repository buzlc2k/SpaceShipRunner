using System;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : Singleton<CanvasManager>
{
    [SerializeField] List<GameStateCanvas> Canvases;

    protected Action<KeyValuePair<EventParameterType, object>> setActiveCanvas;

    protected override void SetUpDelegate()
    {
        base.SetUpDelegate();

        setActiveCanvas ??= (param) => {
            if(!param.Key.Equals(EventParameterType.ChangeGameState_GameState)) return;
            SetActiveCanvas((GameState)param.Value);
        };
    }

    protected override void AddListenerToObsever()
    {
        base.AddListenerToObsever();

        Observer.AddListener(EventID.ChangeGameState, setActiveCanvas);
    }

    protected override void RemoveListenerFromObsever()
    {
        base.RemoveListenerFromObsever();

        Observer.RemoveListener(EventID.ChangeGameState, setActiveCanvas);
    }

    private void SetActiveCanvas(GameState currentGameState){
        foreach(var canvas in Canvases){
            if(currentGameState.Equals(canvas.RespondingState)) canvas.Canvas.SetActive(true);
            else canvas.Canvas.SetActive(false);
        }
    }
}

[Serializable]
public struct GameStateCanvas
{
    public GameState RespondingState; 
    public GameObject Canvas;
}