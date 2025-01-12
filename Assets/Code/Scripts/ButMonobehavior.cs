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
        RegisterListener();
        //For override       
    }

    protected virtual void OnDisable()
    {
        //For override
        UnregisterListener();
    }

    protected virtual void SetUpDelegate(){
        //For override
    }

    protected virtual void RegisterListener(){
        //For override
    }

    protected virtual void UnregisterListener(){
        //For override
    }
}