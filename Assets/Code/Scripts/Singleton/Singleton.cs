using UnityEngine;

public class Singleton <T> : ButMonobehavior where T : ButMonobehavior
{
    private static T _reference;

    public static bool IsValid => _reference != null;

    public bool isDontDestroy;
    
    public static T Instance
    {
        get
        {
            if (!IsValid)  
            {
                _reference = FindAnyObjectByType<T>();
                if (!IsValid) Debug.LogError($"No Instance of {typeof(T).Name} in this scene");
            }
            return _reference;
        }
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        
        if (IsValid && _reference != this)
        {
            Destroy(gameObject);
            Debug.Log("Destroy");
        }
        else
        {
            _reference = (T)(MonoBehaviour)this;
            
            if (isDontDestroy)
            {
                DontDestroyOnLoad(gameObject);
            }
        }
    }
    
}