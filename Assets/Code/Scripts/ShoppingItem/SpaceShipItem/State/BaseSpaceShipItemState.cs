public abstract class BaseSpaceShipItemState : BaseState
{
    public SpaceShipConfig spaceShipConfig;

    public BaseSpaceShipItemState(SpaceShipConfig spaceShipConfig){
        this.spaceShipConfig = spaceShipConfig;
    }

    public abstract void OnStateClick();
}