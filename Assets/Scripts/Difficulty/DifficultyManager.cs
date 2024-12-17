using System.Collections.Generic;
using UnityEngine;

public class DifficultyManager : Singleton<DifficultyManager>
{
    public BaseDifficultyAbstract GameSpeedDifficultyCtrl;
    public BaseDifficultyAbstract ObstacleDifficultyCtrl;

    private bool isCalculating = true; //Có đang tính toán không hay là đang reset rồi mới tính 

    /// <summary>
    /// Tỉ lệ tốc độ hiện tại của trò chơi
    /// </summary>
    public float GameSpeedRate => ((GameSpeedDifficultyCtrl)GameSpeedDifficultyCtrl).GetGameSpeedRate();

    protected override void Start() {
        base.Start();
        
        InitializeUpdateGameDifficulty();
    }

    protected override void Reset()
    {
        base.Reset();

        GameSpeedDifficultyCtrl = GetComponentInChildren<GameSpeedDifficultyCtrl>();
        ObstacleDifficultyCtrl = GetComponentInChildren<ObstacleDifficultyCtrl>();
    }

    /// <summary>
    /// Tiến hành cập nhật độ khó của trò chơi
    /// </summary>
    /// <param name="resumePreviousState ">Có bắt đầu lại từ trạng thái trước đó không</param>
    public void InitializeUpdateGameDifficulty(bool resumePreviousState  = true)
    {
        if((isCalculating && resumePreviousState) || (!isCalculating && !resumePreviousState)){
            isCalculating = true;
            Observer.PostEvent(EventID.InitializeCalculateDifficulty, new KeyValuePair<EventParameterType, object>(EventParameterType.InitializeCalculateDifficulty_null, null));
        }  
        else{
            isCalculating = false;
            Observer.PostEvent(EventID.InitializeResetUpdateCalculateDifficulty, new KeyValuePair<EventParameterType, object>(EventParameterType.InitializeResetUpdateCalculateDifficulty_Null, null));
        }    
    }

    /// <summary>
    /// Tạm dừng cập nhật độ khó của trò chơi
    /// </summary>
    public void PauseUpdateGameDifficulty()
    {
        Observer.PostEvent(EventID.PauseCalculateGameDifficulty, new KeyValuePair<EventParameterType, object>(EventParameterType.PauseCalculateGameDifficulty_Null, null));
    }
}