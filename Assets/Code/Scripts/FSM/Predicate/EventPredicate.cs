using System;
using System.Collections.Generic;
using UnityEngine;

public class EventPredicate: BasePredicate
{
    private readonly EventID listenedEvent;
    private bool isEventTriggered = false;
    private bool predicateRunning = false;
    private readonly Action<KeyValuePair<EventParameterType, object>> onEventTriggered;

    public EventPredicate(EventID listenedEvent){
        this.listenedEvent = listenedEvent;

        onEventTriggered = (param) => {
            if(predicateRunning) isEventTriggered = true;
        };

        Observer.AddListener(this.listenedEvent, onEventTriggered);
    }

    public EventPredicate(EventID listenedEvent, object eventParamenterCondition, bool equalCondition = true){
        this.listenedEvent = listenedEvent;

        onEventTriggered = (param) => {
            if(param.Value.Equals(eventParamenterCondition) == equalCondition)
                if(predicateRunning) isEventTriggered = true;
        };

        Observer.AddListener(this.listenedEvent, onEventTriggered);
    }

    ~EventPredicate(){
        Observer.RemoveListener(listenedEvent, onEventTriggered);
    }

    public override bool Evaluate()
    {
        predicateRunning = true;
        if(!isEventTriggered) return false;

        isEventTriggered = false;
        predicateRunning = false;
        return true;
    }
}