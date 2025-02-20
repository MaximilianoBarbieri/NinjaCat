
using UnityEngine;

public class FallState : State
{
    private Cat _cat;

    public override void OnEnter()
    {
        Debug.Log("FALL STATE");
    }

    public override void OnUpdate()
    {
        _cat.modelCat.Move(Input.GetAxisRaw("Horizontal"));
        
        if (_cat.modelCat.IsGrounded())
            _cat.stateMachine.ChangeState(Cat.CatState.Run);
    }

    public override void OnExit()
    {
    }
}
