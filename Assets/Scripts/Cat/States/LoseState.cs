using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseState : State
{
    private Cat _cat;

    public LoseState(Cat cat) => _cat = cat;

    public override void OnEnter()
    {
        //TODO: animacion de muerte?
        //TODO: Action OnLose para ejecutar OnLoose en las clases correspondientes?
    }

    public override void OnUpdate()
    {
    }

    public override void OnExit()
    {
    }
}