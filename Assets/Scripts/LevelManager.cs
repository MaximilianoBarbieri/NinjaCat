using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Serialization;

public class LevelManager : MonoBehaviour
{
    private Cat _cat => FindObjectOfType<Cat>();

    private float _timer;
    private int coins;
    private int life;

    private bool isAlive;

    private string Distance => _timer.ToString("0.0") + "KM";

    private void Start()
    {
        isAlive = true;

        ItemManager.Instance.OnModifyCoins += GetValueCoins;

        ItemManager.Instance.OnModifyLife += GetValueLife;
    }

    private void GetValueLife(int? amount = null)
    {
        life = _cat.LifeCount;
        UIManager.OnRefreshLife?.Invoke(life);
    }

    private void GetValueCoins(int? amount = null)
    {
        coins = _cat.Coins;
        UIManager.OnRefreshCoins?.Invoke(coins);
    }

    private void Update()
    {
        if (_cat._lifeCount <= 0 && isAlive)
        {
            UIManager.OnFinishGame?.Invoke();
            isAlive = false;
        }
        else if (_cat._lifeCount > 0)
        {
            UIManager.OnRefreshTimer?.Invoke(_timer += Time.deltaTime);
            UIManager.OnRefreshDistance?.Invoke(Distance);
        }
    }
}