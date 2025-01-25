public abstract class BaseSpaceShipItemState : BaseState
{
    public SpaceShipItem SpaceShipItem;

    public BaseSpaceShipItemState(SpaceShipItem SpaceShipItem){
        this.SpaceShipItem = SpaceShipItem;
    }

    public abstract void InitializeStateAction();
}