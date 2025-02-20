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
            else
            {
                _cat.stateMachine.ChangeState(Cat.CatState.Run);
            }
        }
    }
}
