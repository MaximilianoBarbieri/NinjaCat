using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : Item
{
    private const int CoinValue = 1;

    public override void ApplyFX()
    {
    }

    protected override void ProcessEffect()
    {
        ItemManager.OnModifyCoins?.Invoke(CoinValue);
        Debug.Log("Obtuviste una moneda!");
    }
}