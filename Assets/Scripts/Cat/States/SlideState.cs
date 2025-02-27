using UnityEngine;
using static Utils;

public class SlideState : State
{
    private Cat _cat;
    private float _slideDuration = 2f;
    private float _timer;

    public SlideState(Cat cat) => _cat = cat;

    public override void OnEnter()
    {
        _cat.modelCat.ChangeToSlideCollider();
        _cat.viewCat.PLAY_ANIM(PARAM_BOOL_SLIDE, true);
        _timer = _slideDuration;
    }

    public override void OnUpdate()
    {
        if (Input.GetAxisRaw(AXIS_RAW_HORIZONTAL) != 0) _cat.modelCat.Move(Input.GetAxisRaw(AXIS_RAW_HORIZONTAL));
        
        _timer -= Time.deltaTime;
        if (_timer <= 0)
        {
            _cat.stateMachine.ChangeState(Cat.CatState.Run);
        }
    }

    public override void OnExit()
    {
        _cat.modelCat.ResetCollider();
        _cat.viewCat.PLAY_ANIM(PARAM_BOOL_SLIDE, false);
    }
}
