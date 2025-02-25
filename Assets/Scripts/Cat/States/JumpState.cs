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
        //Debug.Log("JumpState");

        if (Input.GetAxisRaw("Horizontal") != 0) _cat.modelCat.Move(Input.GetAxisRaw("Horizontal"));
        //TODO: verificar si toca el suelo para pasar a RUN
    }

    public override void OnExit()
    {
        _cat.viewCat.PLAY_ANIM(PARAM_BOOL_JUMP, false);
    }
    
    //TODO: EJECUTAR EN LA ANIMACION UN CAMBIO DE ESTADO A FALL AL TERMINAR DE HACER EL SALTO
}