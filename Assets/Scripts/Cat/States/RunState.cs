using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunState : State
{
    private Cat _cat;

    public RunState(Cat cat) => _cat = cat;

    public override void OnEnter()
    {
    }

    public override void OnUpdate()
    {
        _cat.modelCat.Move(Input.GetAxisRaw("Horizontal"));

        Debug.Log("MOVE DESDE RUN STATE");
    }

    public override void OnExit()
    {
    }
}