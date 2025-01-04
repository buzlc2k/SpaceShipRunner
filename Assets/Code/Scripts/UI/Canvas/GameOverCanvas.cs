using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameOverCanvas : BaseCanvas
{  
    public GameObject CountDownText; 
    public GameObject ContinueButton;
    [HideInInspector] public float CountDownTime = 5f;

    protected override void LoadComponents()
    {
        base.LoadComponents();

        if(CountDownText == null) CountDownText = GetComponentInChildren<GameOver_CountDownText>().gameObject;
        if(ContinueButton == null) ContinueButton = GetComponentInChildren<GameOver_ContinueButton>().gameObject;
    }

    protected override void LoadValue()
    {
        base.LoadValue();

        CountDownTime = 5f;
    }

    protected override void OnEnable()
    {
        base.OnEnable();

        SwitchCountDownTextAndResumeButton();
        Invoke(nameof(SwitchCountDownTextAndResumeButton), CountDownTime);
    }

    private void Update() {
        CountDownTimer();
    }

    private void CountDownTimer(){
        if(CountDownTime > 0) {
            CountDownTime -= Time.deltaTime;
        }
    }    

    private void SwitchCountDownTextAndResumeButton(){
        bool countDownTextEnable = CountDownText.activeSelf;
        
        CountDownText.SetActive(!countDownTextEnable);
        ContinueButton.SetActive(countDownTextEnable);
    }
}