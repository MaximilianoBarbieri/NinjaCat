using UnityEngine;
using static Utils;

public class JumpState : State
{
    private Cat _cat;

    public JumpState(Cat cat) => _cat = cat;

    public override void OnEnter()
    {
        _cat.viewCat.PLAY_ANIM(PARAM_BOOL_JUMP, true);
        _cat.modelCat.Jump();
    }

    public override void OnUpdate()
    {
        _cat.modelCat.Move(Input.GetAxisRaw("Horizontal"));

        Debug.Log("MOVE DESDE JUMP STATE");
    }

    public override void OnExit()
    {
        _cat.viewCat.PLAY_ANIM(PARAM_BOOL_JUMP, false);
    }
    
    //TODO: EJECUTAR EN LA ANIMACION UN CAMBIO DE ESTADO A FALL AL TERMINAR DE HACER EL SALTO
}