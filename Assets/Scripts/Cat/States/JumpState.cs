using UnityEngine;

public class JumpState : State
{
    private Cat _cat;
    private float _currentJumpDuration;
    private bool _isGoingUp;

    public JumpState(Cat cat) => _cat = cat;

    public override void OnEnter() => _isGoingUp = true;

    public override void OnUpdate()
    {
        if (_isGoingUp)
        {
            _cat.modelCat.JumpHandler(Vector3.up);
            _currentJumpDuration += Time.deltaTime;

            if (_currentJumpDuration >= _cat.JumpDuration / 2f)
            {
                _isGoingUp = false;
                _currentJumpDuration = 0f;
            }
        }
        else
        {
            _cat.modelCat.JumpHandler(Vector3.down);
            _currentJumpDuration += Time.deltaTime;

            if (_cat.modelCat.TouchGround() && _currentJumpDuration >= _cat.JumpDuration / 2f)
                _cat.stateMachine.ChangeState(Cat.CatState.Run);
        }
    }

    public override void OnExit() => _currentJumpDuration = 0;
}