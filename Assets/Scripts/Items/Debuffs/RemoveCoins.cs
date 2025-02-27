using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveCoins : Debuff
{
    private int _removeValue = -5;

    protected override void ProcessEffect()
    {
        if (Cat.Coins > 0)
            ItemManager.OnModifyCoins?.Invoke(_removeValue);
    }
}