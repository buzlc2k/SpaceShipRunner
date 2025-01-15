using System;
using System.Collections.Generic;

public class StateMachine
{
    StateNode current;
    Dictionary<Type, StateNode> nodes = new();

    public void StateMachineUpdate(){
        var transition = GetTransition();
        if (transition != null)
            ChangeState(transition.To);
    }

    public void SetState(BaseGameState state) {
        current = nodes[state.GetType()];
        current.State?.OnEnterState();
    }

    private void ChangeState(BaseGameState state){
        if (state == current.State) return;

        var previousState = current.State;
        var nextState = nodes[state.GetType()].State;

        previousState?.OnExitState();
        nextState?.OnEnterState();
        current = nodes[state.GetType()];
    }

    Transition GetTransition() {
        if(current.Transitions.Count == 0) return null;
                    
        foreach (var transition in current.Transitions)
            if (transition.Condition.Evaluate())
                return transition;
            
        return null;
    }

    public void AddTransition(BaseGameState from, BaseGameState to, BasePredicate condition) {
        GetOrAddStateNode(from).AddTransition(GetOrAddStateNode(to).State, condition);
    }

    StateNode GetOrAddStateNode(BaseGameState state) {
        var node = nodes.GetValueOrDefault(state.GetType());
            
        if (node == null) {
            node = new StateNode(state);
            nodes.Add(state.GetType(), node);
        }
            
        return node;
    }

    class StateNode {
        public BaseGameState State { get; }
        public HashSet<Transition> Transitions { get; }
            
        public StateNode(BaseGameState state) {
            State = state;
            Transitions = new HashSet<Transition>();
        }
            
        public void AddTransition(BaseGameState to, BasePredicate condition) {
            Transitions.Add(new Transition(to, condition));
        }
    }
}