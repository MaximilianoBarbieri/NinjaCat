using System.Collections;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private Cat _cat => FindObjectOfType<Cat>();

    private float _timer;
    private int _coins;
    private int _life;
    private bool _isGameOver;
    
    private string Distance => _timer.ToString("0.0") + "KM";

    private void Start()
    {
        ItemManager.Instance.OnModifyCoins += GetValueCoins;
        ItemManager.Instance.OnModifyLife += GetValueLife;

        UIManager.OnFinishGame += HandleGameOver;
    }

    private void GetValueLife(int? amount = null)
    {
        _life = _cat.LifeCount;
        UIManager.OnRefreshLife?.Invoke(_life);
    }

    private void GetValueCoins(int? amount = null)
    {
        _coins = _cat.Coins;
        UIManager.OnRefreshCoins?.Invoke(_coins);
    }

    private void Update()
    {
        if (_isGameOver) return;

        UIManager.OnRefreshTimer?.Invoke(_timer += Time.deltaTime);
        UIManager.OnRefreshDistance?.Invoke(Distance);
    }

    private void HandleGameOver()
    {
        _isGameOver = true;
        Debug.Log("Ahora LevelManager ha sido detenido.");
    }

    private void OnDestroy()
    {
        UIManager.OnFinishGame -= HandleGameOver;
        ItemManager.Instance.OnModifyCoins -= GetValueCoins;
        ItemManager.Instance.OnModifyLife -= GetValueLife;
    }
}