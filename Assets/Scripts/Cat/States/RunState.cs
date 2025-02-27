using UnityEngine;
using static Utils;

public class RunState : State
{
    private Cat _cat;

    public RunState(Cat cat) => _cat = cat;

    public override void OnEnter()
    { 
        _cat.viewCat.PLAY_ANIM(PARAM_BOOL_RUN, true);
    }

    public override void OnUpdate()
    {
        if (Input.GetAxisRaw(AXIS_RAW_HORIZONTAL) != 0) _cat.modelCat.Move(Input.GetAxisRaw(AXIS_RAW_HORIZONTAL));
    }

    public override void OnExit()
    {
        _cat.viewCat.PLAY_ANIM(PARAM_BOOL_RUN, false);
    }
}