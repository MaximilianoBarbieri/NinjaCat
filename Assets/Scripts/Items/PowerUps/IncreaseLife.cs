using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Utils;

public class IncreaseLife : Buff
{
    protected override void ProcessEffect()
    {
        if (Cat.LifeCount < MAX_LIFECOUNT)
            ItemManager.OnModifyLife?.Invoke(1);
    }
}