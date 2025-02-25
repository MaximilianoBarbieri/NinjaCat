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
        //Debug.Log("RunState");

        if (Input.GetAxisRaw("Horizontal") != 0) _cat.modelCat.Move(Input.GetAxisRaw("Horizontal"));
    }

    public override void OnExit()
    {
        _cat.viewCat.PLAY_ANIM(PARAM_BOOL_RUN, false);
    }
}