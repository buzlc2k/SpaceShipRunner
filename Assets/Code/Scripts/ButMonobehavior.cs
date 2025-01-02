using UnityEngine;

public abstract class ButMonobehavior : MonoBehaviour
{
    protected virtual void Awake()
    {
        LoadComponents();
        //For override
    }

    protected virtual void Start()
    {
        //For override
    }

    protected virtual void Reset()
    {
        LoadComponents();
        LoadValue();
        //For override
    }

    protected virtual void LoadComponents()
    {
        //For override
    }

    protected virtual void LoadValue()
    {
        //For override
    }

    protected virtual void ResetValue(){
        LoadValue();
        //For override
    }

    protected virtual void OnEnable()
    {
        ResetValue();
        SetUpDelegate();
        AddListenerToObsever();
        //For override

        
    }

    protected virtual void OnDisable()
    {
        //For override
        RemoveListenerFromObsever();
    }

    protected virtual void SetUpDelegate(){
        //For override
    }

    protected virtual void AddListenerToObsever(){
        //For override
    }

    protected virtual void RemoveListenerFromObsever(){
        //For override
    }
}