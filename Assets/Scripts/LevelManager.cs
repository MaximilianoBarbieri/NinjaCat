using System.Collections;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private Cat _cat => FindObjectOfType<Cat>();

    private float _timer;
    private int coins;
    private int life;

    private bool isGameOver;

    private string Distance => _timer.ToString("0.0") + "KM";

    private void Start()
    {
        ItemManager.Instance.OnModifyCoins += GetValueCoins;
        ItemManager.Instance.OnModifyLife += GetValueLife;
        
        UIManager.OnFinishGame += HandleGameOver;
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
        if (isGameOver) return; // 🔥 Evitar actualizaciones después del Game Over

        UIManager.OnRefreshTimer?.Invoke(_timer += Time.deltaTime);
        UIManager.OnRefreshDistance?.Invoke(Distance);
    }
    
    private void HandleGameOver()
    {
        isGameOver = true;
        Debug.Log("Ahora LevelManager ha sido detenido.");
    }

    private void OnDestroy()
    {
        UIManager.OnFinishGame -= HandleGameOver;
        ItemManager.Instance.OnModifyCoins -= GetValueCoins;
        ItemManager.Instance.OnModifyLife -= GetValueLife;
    }
}