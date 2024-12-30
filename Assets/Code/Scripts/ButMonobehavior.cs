using UnityEngine;

public abstract class ButMonobehavior : MonoBehaviour
{
    protected virtual void Awake()
    {
        this.LoadComponents();
        //For override
    }

    protected virtual void Start()
    {
        //For override
    }

    protected virtual void Reset()
    {
        this.LoadComponents();
        this.LoadValue();
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
        this.ResetValue();
        //For override
    }

    protected virtual void OnDisable()
    {
        //For override
    }
}