using System;
using System.Collections.Generic;

public class EventPredicate: BasePredicate
{
    private readonly EventID listenedEvent;
    private bool isEventTriggered = false;
    private readonly Action<KeyValuePair<EventParameterType, object>> onEventTriggered;

    public EventPredicate(EventID listenedEvent){
        this.listenedEvent = listenedEvent;

        onEventTriggered = (param) => {
            isEventTriggered = true;
        };

        Observer.AddListener(this.listenedEvent, onEventTriggered);
    }

    public EventPredicate(EventID listenedEvent, object eventParamenterCondition, bool equalCondition = true){
        this.listenedEvent = listenedEvent;

        onEventTriggered = (param) => {
            if(param.Value.Equals(eventParamenterCondition) == equalCondition)
                isEventTriggered = true;
        };

        Observer.AddListener(this.listenedEvent, onEventTriggered);
    }

    ~EventPredicate(){
        Observer.RemoveListener(listenedEvent, onEventTriggered);
    }

    public override bool Evaluate()
    {
        if(!isEventTriggered) return false;

        isEventTriggered = false;
        return true;
    }
}