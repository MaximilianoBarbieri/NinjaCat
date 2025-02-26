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
    public Action<int?> OnModifyCoins;
    public Action<int?> OnModifyLife;

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
        OnRequestRoad += RequestCoins;

        OnModifyControls = (b) => IsReverseControls = b;

        OnModifyCoins = (i) => _cat.Coins += i ?? 0;

        OnModifyLife = (i) => _cat.LifeCount += i ?? 0;
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

    private void RequestCoins(GameObject road)
    {
        foreach (Transform child in road.GetComponentsInChildren<Transform>())
        {
            if (child.name == "SpawnCoins")
            {
                // Eliminar todas las monedas existentes en el SpawnCoins
                foreach (Transform existingCoin in child)
                {
                    Destroy(existingCoin.gameObject);
                }

                // Generar 5 monedas con una separación de 1 unidad en el eje Z
                for (int i = 0; i < 5; i++)
                {
                    Vector3 spawnPosition = child.position + new Vector3(0, 0, i);
                    Instantiate(Coin, spawnPosition, Quaternion.identity, child);
                }
            }
        }
    }

}