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
        _cat.modelCat.Move(Input.GetAxisRaw("Horizontal"));

        Debug.Log("MOVE DESDE RUN STATE");
    }

    public override void OnExit()
    {
        _cat.viewCat.PLAY_ANIM(PARAM_BOOL_RUN, false);
    }
}