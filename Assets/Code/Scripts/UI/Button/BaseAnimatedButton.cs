using DG.Tweening;

public abstract class BaseAnimatedButton : BaseButton
{
    protected Sequence buttonSquence;

    protected override void OnDisable(){
        base.OnDisable();

        buttonSquence?.Kill();
    }

    protected abstract void InitializeAnimation();
}