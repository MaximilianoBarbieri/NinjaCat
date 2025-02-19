using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamageState : State
{
    private Cat _cat;

    public TakeDamageState(Cat cat) => _cat = cat;
    
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