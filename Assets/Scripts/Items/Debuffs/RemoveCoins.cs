using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveCoins : Debuff
{
    private int _removeValue = 5;

    public override void ProcessEffect()
    {
        if (_cat.Coins > 0)
            ItemManager.OnModifyCoins?.Invoke(_removeValue);
    }
}