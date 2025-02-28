using UnityEngine;
using UnityEngine.SceneManagement;
using static Utils;

public class Controller
{
    private Cat _cat;
    public Controller(Cat cat) => _cat = cat;

    public void ControllerUpdate()
    {
        Debug.Log("---- STATE ACTUAL " + _cat.stateMachine.getCurrentState());

        if (!_cat.modelCat.IsGrounded()) return;

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) && CanJump())
        {
            _cat.stateMachine.ChangeState(Cat.CatState.Jump);
        }
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow) && CanSlide())
        {
            _cat.stateMachine.ChangeState(Cat.CatState.Slide);
        }
        else if (CanRun())
        {
            _cat.stateMachine.ChangeState(Cat.CatState.Run);
        }

        if (Input.GetKeyDown(KeyCode.Escape)) Application.Quit();
    }

    private bool CanJump()
    {
        return _cat.stateMachine.getCurrentState() switch
        {
            STATE_RUN => true,
            STATE_DAMAGE => true,
            _ => false
        };
    }

    private bool CanSlide()
    {
        return _cat.stateMachine.getCurrentState() switch
        {
            STATE_RUN => true,
            STATE_DAMAGE => true,
            _ => false
        };
    }

    private bool CanRun()
    {
        return _cat.stateMachine.getCurrentState() switch
        {
            STATE_JUMP => true,
            STATE_DAMAGE => true,
            _ => false
        };
    }
}