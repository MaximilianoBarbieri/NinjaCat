using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinState : State
{
    private Cat _cat;

    public WinState(Cat cat) => _cat = cat;

    public override void OnEnter()
    {
    }

    public override void OnUpdate()
    {
    }

    public override void OnExit()
    {
    }
}