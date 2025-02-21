using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    private Cat _cat;

    [Header("Debuffs")] public static Action<float> OnModifyControls;

    public static ItemManager Instance { get; private set; }

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

        OnModifyControls = (f) => _cat.Speed *= f;
    }
}