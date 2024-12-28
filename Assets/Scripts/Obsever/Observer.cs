using System;
using System.Collections.Generic;
using UnityEngine;

public class Observer
{
    /// Store all "listener"
    private static Dictionary<EventID, List<Action<KeyValuePair<EventParameterType, object>>>> Events = new();

    /// <summary>
	/// Register to listen for eventID
	/// </summary>
	/// <param name="eventID">EventID that object want to listen</param>
	/// <param name="callback">Callback will be invoked when this eventID be raised</param>
    public static void AddListener(EventID eventID, Action<KeyValuePair<EventParameterType, object>> callback)
    {
        if (!Events.TryGetValue(eventID, out var eventList))
        {
            eventList = new List<Action<KeyValuePair<EventParameterType, object>>>();
            Events[eventID] = eventList;
        }
        eventList.Add(callback);
    }

    /// <summary>
	/// Removes the listener. Use to Unregister listener
	/// </summary>
	/// <param name="eventID">EventID.</param>
	/// <param name="callback">Callback want to remove in event list.</param>
    public static void RemoveListener(EventID eventID, Action<KeyValuePair<EventParameterType, object>> callback)
    {
        if (!Events.TryGetValue(eventID, out var eventList)) return;
        eventList.Remove(callback);

        // Clean up empty event list
        if (eventList.Count == 0)
        {
            Events.Remove(eventID);
        }
    }

    /// <summary>
	/// Posts the event. This will notify all listener that register for this event
	/// </summary>
	/// <param name="eventID">EventID.</param>
	/// <param name="param">Parameter. Listener will make a cast to get the data</param>
    public static void PostEvent(EventID eventID, KeyValuePair<EventParameterType, object> param)
    {
        if (!Events.TryGetValue(eventID, out var eventList)) return;
        foreach (var callback in eventList)
        {
            callback(param);
        }
    }

    /// <summary>
	/// Clears all the listener.
	/// </summary>
    public static void ClearAllListeners()
    {
        Events.Clear();
    }
}
