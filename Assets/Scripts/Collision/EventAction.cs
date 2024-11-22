using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Base Class của EventAction, các lớp kế thừa định nghĩa ra các Action được sử dụng trong các Event
/// Sử dụng để đăng ký giao tiếp với các Obj con hoặc Obj khác trong cùng 1 Obj parent
/// </summary>
public abstract class EventAction : MonoBehaviour
{
    private UnityAction cachedAction;

    private void Awake()
    {
        cachedAction = Act();
    }

    /// <summary>
    /// Đăng ký Action này vào trong Event
    /// </summary>
    /// <param name="_unityEvent">Đối tượng cần kiểm tra.</param>
    public void RegisterListener(UnityEvent _unityEvent)
    {
        _unityEvent.AddListener(cachedAction);
    }

    protected abstract UnityAction Act();
}