using static Utils;

public class TakeDamageState : State
{
    private Cat _cat;

    public TakeDamageState(Cat cat) => _cat = cat;
    
    public override void OnEnter()
    {
        _cat.viewCat.PLAY_ANIM_TRIGGER(PARAM_TRIGGER_DAMAGE);
    }

    public override void OnUpdate()
    {
    }

    public override void OnExit()
    {
    }
}