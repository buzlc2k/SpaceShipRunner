using UnityEngine;

public class PauseGameManager : Singleton<PauseGameManager>
{
    public void PauseGame(){
        Time.timeScale = 0;
    }

    public void ResumeGame(){
        Time.timeScale = 1;
    }
}