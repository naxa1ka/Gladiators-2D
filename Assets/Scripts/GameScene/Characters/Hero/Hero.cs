using Cysharp.Threading.Tasks;

public class Hero : Character
{
    private ElementType _currentActionElementType;
    
    public void SetNextAction(ElementType elementType)
    {
        _currentActionElementType = elementType;
    }

    public async UniTask Opening()
    {
        var millisecondsCurrentAnimation = Animator.PlayAndGetMillisecondsCurrentAnimation(AnimationHeroController.States.Opening);
        await UniTask.Delay(millisecondsCurrentAnimation);
    }
    
    public override void ReceiveDamage(float damage)
    {
        if (_currentActionElementType == ElementType.Shield)
        {
            Animator.Play(AnimationHeroController.States.Defense);
        }
        else
        {
            ReceivingDamage(damage);
        }
    }
}