using System;
using UnityEngine;
using UnityEngine.Serialization;

public class LevelManager : MonoBehaviour
{
    private Cat _cat;

    private float _timer;

    public int coins;
    public int life;
    private string Distance => _timer.ToString("0.0") + "KM";

    private void Start()
    {
        ItemManager.Instance.OnModifyCoins += GetValueCoins;

        ItemManager.Instance.OnModifyLife += GetValueLife;
    }

    private void GetValueLife(int value)
    {
        life = _cat.LifeCount;
        UIManager.OnRefreshLife?.Invoke(life);
    }

    private void GetValueCoins(int value)
    {
        coins = _cat.Coins;
        UIManager.OnRefreshCoins?.Invoke(coins);
    }

    private void Update()
    {
        UIManager.OnRefreshTimer?.Invoke(_timer += Time.deltaTime);
        UIManager.OnRefreshDistance?.Invoke(Distance);
    }
}