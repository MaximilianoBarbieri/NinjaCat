using static Utils;

public class LoseState : State
{
    private Cat _cat;

    public LoseState(Cat cat) => _cat = cat;

    public override void OnEnter()
    {
        //TODO: crear swith con tipo de muerte a ejecutar.
        _cat.viewCat.PLAY_ANIM_TRIGGER(PARAM_TRIGGER_DEAD_ONE);
        //_cat.viewCat.PLAY_ANIM_TRIGGER(PARAM_TRIGGER_DEAD_TWO);
        //_cat.viewCat.PLAY_ANIM_TRIGGER(PARAM_TRIGGER_DEAD_THREE);
        //_cat.viewCat.PLAY_ANIM_TRIGGER(PARAM_TRIGGER_DEAD_FOUR);
        //TODO: Action OnLose para ejecutar OnLoose en las clases correspondientes?
    }

    public override void OnUpdate()
    {
    }

    public override void OnExit()
    {
    }
}