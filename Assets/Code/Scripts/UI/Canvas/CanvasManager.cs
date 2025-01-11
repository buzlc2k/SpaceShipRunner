using System;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : Singleton<CanvasManager>
{
    private BaseCanvas currentCanvas;
    [SerializeField] private List<BaseCanvas> canvases = new();
    protected Action<KeyValuePair<EventParameterType, object>> setActiveCanvas;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        
        if (canvases == null || canvases.Count == 0)
        {
            canvases.AddRange(GetComponentsInChildren<BaseCanvas>());
        }
    }

    protected override void SetUpDelegate()
    {
        base.SetUpDelegate();

        setActiveCanvas ??= (param) => {
            if(!param.Key.Equals(EventParameterType.ChangeGameState_GameState)) return;
            SetActiveCanvas((GameState)param.Value);
        };
    }

    protected override void RegisterListener()
    {
        base.RegisterListener();

        Observer.AddListener(EventID.ChangeGameState, setActiveCanvas);
    }

    protected override void UnregisterListener()
    {
        base.UnregisterListener();

        Observer.RemoveListener(EventID.ChangeGameState, setActiveCanvas);
    }

    private void SetActiveCanvas(GameState currentGameState){
        if(currentCanvas != null) 
            currentCanvas.gameObject.SetActive(false);

        foreach(var canvas in canvases){
            if(!currentGameState.Equals(canvas.RespondingState)) continue;
            canvas.gameObject.SetActive(true);
            currentCanvas = canvas;
        }
    }
}