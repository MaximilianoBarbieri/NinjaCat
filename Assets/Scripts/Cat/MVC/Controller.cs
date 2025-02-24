using UnityEngine;

public class Controller
{
    private Cat _cat;
    public Controller(Cat cat) => _cat = cat;

    public void ControllerUpdate()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            _cat.stateMachine.ChangeState(Cat.CatState.Jump);
        }
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            _cat.stateMachine.ChangeState(Cat.CatState.Slide);
        }
        else
        {
            _cat.stateMachine.ChangeState(Cat.CatState.Run);
        }
    }
}
