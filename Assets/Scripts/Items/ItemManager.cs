using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using System.Linq;
using UnityEngine.Events;

public class ItemManager : MonoBehaviour
{
    private Cat _cat => FindObjectOfType<Cat>();

    public Action<bool> OnModifyControls;
    public Action<int> OnModifyCoins;
    public Action<int> OnModifyLife;

    [SerializeField] private List<Item> items = new();
    [SerializeField] private Coin Coin;
    public static ItemManager Instance { get; set; }
    public static bool IsReverseControls;

    public Action<GameObject> OnRequestRoad;

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
        OnRequestRoad += RequestItem;

        OnModifyControls = (b) => IsReverseControls = b;

        OnModifyCoins = (i) => _cat.Coins += i;

        OnModifyLife = (i) => _cat.LifeCount += i;
    }

    private void RequestItem(GameObject road)
    {
        List<Transform> spawnPoints = new List<Transform>();

        foreach (Transform child in road.GetComponentsInChildren<Transform>())
        {
            if (child.name == Utils.NAME_SPAWNPOINT)
            {
                foreach (Transform existingItem in child)
                {
                    Destroy(existingItem.gameObject);
                }

                spawnPoints.Add(child);
            }
        }

        if (spawnPoints.Count == 0 || items.Count == 0) return;

        List<Transform> selectedSpawnPoints = spawnPoints.OrderBy(x => UnityEngine.Random.value).Take(2).ToList();

        foreach (Transform spawnPoint in selectedSpawnPoints)
        {
            Item randomItem = items[UnityEngine.Random.Range(0, items.Count)];
            Instantiate(randomItem, spawnPoint.position, Quaternion.identity, spawnPoint);
        }
    }
}