using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseLife : Buff
{
    public override void ProcessEffect()
    {
        if (_cat.LifeCount < Utils.MAX_LIFECOUNT)
            ItemManager.OnModifyLife?.Invoke(1);
    }
}