using UnityEngine;

public class JumpState : State
{
    private Cat _cat;

    public JumpState(Cat cat) => _cat = cat;

    public override void OnEnter()
    {
        _cat.modelCat.Jump();

        _cat.modelCat.isJumping = true;
    }

    public override void OnUpdate()
    {
        _cat.modelCat.Move(Input.GetAxisRaw("Horizontal"));

        Debug.Log("MOVE DESDE JUMP STATE    ");
    }

    public override void OnExit()
    {
        _cat.modelCat.isJumping = false;
    }
}