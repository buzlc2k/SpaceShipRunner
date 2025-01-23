public class Transition
{
    public BaseState To { get; }
    public BasePredicate Condition { get; }

    public Transition(BaseState To, BasePredicate Condition){
        this.To = To;
        this.Condition = Condition;
    }
}