using UnityEngine;
using static Utils;

public class JumpState : State
{
    private Cat _cat;

    public JumpState(Cat cat) => _cat = cat;

    public override void OnEnter()
    {
        _cat.viewCat.PLAY_ANIM(PARAM_BOOL_JUMP, true);
        _cat.modelCat.Jump();
    }

    public override void OnUpdate()
    {
        if (Input.GetAxisRaw(AXIS_RAW_HORIZONTAL) != 0) _cat.modelCat.Move(Input.GetAxisRaw(AXIS_RAW_HORIZONTAL));
    }

    public override void OnExit()
    {
        _cat.viewCat.PLAY_ANIM(PARAM_BOOL_JUMP, false);
    }
}