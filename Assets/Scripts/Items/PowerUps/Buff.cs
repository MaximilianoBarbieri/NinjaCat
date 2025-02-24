using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Buff : Item
{
    public override void ApplyFX()
    {
        Fx.Play();
    }
}