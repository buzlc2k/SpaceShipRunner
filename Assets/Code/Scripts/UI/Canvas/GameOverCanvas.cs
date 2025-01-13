using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverCanvas : BaseCanvas
{  
    public GameObject CountDownText; 
    public GameObject ContinueButton;
    public GameObject ReviveButton;
    [HideInInspector] public float CountDownTime = 10f;

    protected override void LoadComponents()
    {
        base.LoadComponents();

        if(RespondingState.Equals(GameState.None)) RespondingState = GameState.Over;
        if(CountDownText == null) CountDownText = GetComponentInChildren<GameOver_CountDownText>().gameObject;
        if(ContinueButton == null) ContinueButton = GetComponentInChildren<GameOver_ContinueButton>().gameObject;
        if(ReviveButton == null) ReviveButton = GetComponentInChildren<GameOver_ReviveButton>().gameObject;
    }

    protected override void ResetValue()
    {
        base.ResetValue();

        if(!AdsManager.Instance.InternetReachable || GameManager.Instance.CurrentGameSession > 1) {
            ReviveButton.SetActive(false);
            ContinueButton.SetActive(true);
        }
        else{
            ReviveButton.SetActive(true);
            ContinueButton.SetActive(false);
        }

        CountDownText.SetActive(true);
    }

    protected override void OnEnable()
    {
        base.OnEnable();

        StartCoroutine(CountDownTimer());
    }

    private IEnumerator CountDownTimer(){
        CountDownTime = 10f;
        while(CountDownTime > 0){
            CountDownTime -= Time.deltaTime;
            yield return null;
        }

        Observer.PostEvent(EventID.GameOver_FinishGameOver, new KeyValuePair<EventParameterType, object>(EventParameterType.GameOver_FinishGameOver_Null, null));
    }
}