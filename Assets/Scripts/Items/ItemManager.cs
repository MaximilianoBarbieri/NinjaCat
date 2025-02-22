using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    private Cat _cat;

    public Action<bool> OnModifyControls;
    public Action<int> OnModifyCoins;
    public Action<int> OnModifyLife;

    public static ItemManager Instance { get; private set; }
    public static bool IsReverseControls;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    private void Start()
    {
        _cat = GetComponent<Cat>();

//        OnModifyControls = (f) => _cat.Speed *= f;


        OnModifyControls = (b) => IsReverseControls = b;

        OnModifyCoins = (i) => _cat.Coins += i;

        OnModifyLife = (i) => _cat.LifeCount += i;
    }
}