using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    private bool isCalculating = true; //Có đang tính toán không hay là đang reset rồi mới tính 

    protected override void Start()
    {
        base.Start();

        InitializeUpdateGame();
    }

    /// <summary>
    /// Tiến hành cập nhật trò chơi
    /// </summary>
    /// <param name="resumePreviousState ">Có bắt đầu lại từ trạng thái trước đó không</param>
    public void InitializeUpdateGame(bool resumePreviousState  = true)
    {
        if((isCalculating && resumePreviousState) || (!isCalculating && !resumePreviousState)){
            isCalculating = true;
            Observer.PostEvent(EventID.InitializeUpdateGame, new KeyValuePair<EventParameterType, object>(EventParameterType.InitializeUpdateGame_Null, null));
        }  
        else{
            isCalculating = false;
            Observer.PostEvent(EventID.InitializeResetUpdateGame, new KeyValuePair<EventParameterType, object>(EventParameterType.InitializeResetUpdateGame_Null, null));
        }    
    }

    /// <summary>
    /// Tạm dừng cập nhật trò chơi
    /// </summary>
    public void PauseUpdateGame()
    {
        Observer.PostEvent(EventID.PauseUpdateGame, new KeyValuePair<EventParameterType, object>(EventParameterType.PauseUpdateGame_Null, null));
    }
}