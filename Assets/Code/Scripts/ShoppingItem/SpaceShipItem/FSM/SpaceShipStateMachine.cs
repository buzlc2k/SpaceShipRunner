public class SpaceShipStateMachine : StateMachine
{
    public void ClickInState(){
        ((BaseSpaceShipItemState)current.State).OnStateClick();
    }
}