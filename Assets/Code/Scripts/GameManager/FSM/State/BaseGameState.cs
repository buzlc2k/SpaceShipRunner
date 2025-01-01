public abstract class BaseGameState
{
    protected GameManager gameManager;

    public BaseGameState(GameManager gameManager){
        this.gameManager = gameManager;
    }

    public abstract void OnEnterState();
    public abstract void OnExitState();
}