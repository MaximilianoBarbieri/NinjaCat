using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : Item
{
    public int CoinValue { get; }

    public override void ApplyFX()
    {
    }

    public override void ProcessEffect()
    {
        ItemManager.OnModifyCoins?.Invoke(CoinValue);
        Debug.Log("Obtuviste una moneda!");
    }
}