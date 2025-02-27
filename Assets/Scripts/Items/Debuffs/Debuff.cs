using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Debuff : Item
{
    public override void ApplyFX()
    {
        _fx.Play();
    }
}