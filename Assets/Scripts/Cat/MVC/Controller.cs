using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller
{
    private Cat _cat;
    public Controller(Cat cat) => _cat = cat;

    public void ControllerUpdate()
    {
        _cat.modelCat.IsGrounded();

        if (Input.GetKeyDown(KeyCode.Space) && _cat.modelCat.isGround)
            _cat.stateMachine.ChangeState(Cat.CatState.Jump);
    }
}