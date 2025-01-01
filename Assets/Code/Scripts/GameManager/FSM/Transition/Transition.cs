public class Transition
{
    public BaseGameState To { get; }
    public BasePredicate Condition { get; }

    public Transition(BaseGameState To, BasePredicate Condition){
        this.To = To;
        this.Condition = Condition;
    }
}