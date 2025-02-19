using UnityEngine;

public class JumpState : State
{
    private Cat _cat;

    public JumpState(Cat cat) => _cat = cat;

    public override void OnEnter()
    {
        _cat.modelCat.Jump();
    }

    public override void OnUpdate()
    {
    }

    public override void OnExit()
    {
    }
}