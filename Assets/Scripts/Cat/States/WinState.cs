using static Utils;

public class WinState : State
{
    private Cat _cat;

    public WinState(Cat cat) => _cat = cat;

    public override void OnEnter()
    {
        _cat.viewCat.PLAY_ANIM_TRIGGER(PARAM_TRIGGER_DEAD_WIN);
    }

    public override void OnUpdate()
    {
    }

    public override void OnExit()
    {
    }
}