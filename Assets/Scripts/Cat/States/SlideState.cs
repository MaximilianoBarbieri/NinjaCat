using UnityEngine;
using static Utils;

public class SlideState : State
{
    private Cat _cat;

    public SlideState(Cat cat) => _cat = cat;

    public override void OnEnter()
    { 
        _cat.viewCat.PLAY_ANIM(PARAM_BOOL_SLIDE, true);
    }

    public override void OnUpdate()
    {
        if (Input.GetAxisRaw("Horizontal") != 0) _cat.modelCat.Move(Input.GetAxisRaw("Horizontal"));
    }

    public override void OnExit()
    {
        _cat.viewCat.PLAY_ANIM(PARAM_BOOL_SLIDE, false);
    }
}
