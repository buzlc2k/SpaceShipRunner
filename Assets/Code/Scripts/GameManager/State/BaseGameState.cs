public abstract class BaseGameState : BaseState
{
    protected GameManager gameManager;

    public BaseGameState(GameManager gameManager){
        this.gameManager = gameManager;
    }
}