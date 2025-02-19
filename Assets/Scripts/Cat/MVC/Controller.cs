using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller
{
    private Cat _cat;
    public Controller(Cat cat) => _cat = cat;

    public void ControllerUpdate()
    {
        if (_cat.modelCat.IsGrounded())
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _cat.stateMachine.ChangeState(Cat.CatState.Jump);
            }
            else if (Input.GetAxisRaw("Horizontal") != 0 && _cat.modelCat.isJumping)
            {
                _cat.stateMachine.ChangeState(Cat.CatState.Run);
            }
        }
    }
}