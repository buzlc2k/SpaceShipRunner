public class SpaceShipStateMachine : StateMachine
{
    public void InitializeStateAction(){
        ((BaseSpaceShipItemState)current.State).InitializeStateAction();
    }
}