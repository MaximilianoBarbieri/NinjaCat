using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    //TODO: TIEMPO // DISTANCIA // COINS

    private LevelManager _levelManager => FindObjectOfType<LevelManager>();

    [SerializeField] private TextMeshProUGUI timer;
    [SerializeField] private TextMeshProUGUI coins;
    [SerializeField] private TextMeshProUGUI distance;

    [SerializeField] private TextMeshProUGUI finalStats;

    [SerializeField] private Image currentItem;
    [SerializeField] private Image currentItemColor;

    [SerializeField] private Image firstHearth;
    [SerializeField] private Image secondHearth;
    [SerializeField] private Image threeHearth;

    [SerializeField] private GameObject panelStatistics;

    [SerializeField] private Button buttonReturnMenu;
    [SerializeField] private Button buttonPlay;
    [SerializeField] private Button buttonReplay;

    public static Action<int> OnRefreshCoins;
    public static Action<float> OnRefreshTimer;
    public static Action<string> OnRefreshDistance;
    public static Action<int> OnRefreshLife;

    public static Action<Image, Color> OnRefreshCurrentItem;

    public static Action OnFinishGame;

    private void RefreshCoins(int value) => coins.text = $"{value}";
    private void RefreshTimer(float value) => timer.text = Mathf.FloorToInt(value).ToString();
    private void RefreshDistance(string value) => distance.text = value;

    private void RefreshItem(Image image, Color color)
    {
        currentItem = image;
        currentItemColor.color = color;
    }

    private void RefreshLife(int value)
    {
        firstHearth.gameObject.SetActive(value >= 1);
        secondHearth.gameObject.SetActive(value >= 2);
        threeHearth.gameObject.SetActive(value >= 3);
    }
    
    private void Start()
    {
        OnRefreshCoins += RefreshCoins;
        OnRefreshTimer += RefreshTimer;
        OnRefreshLife += RefreshLife;
        OnRefreshDistance += RefreshDistance;
        OnRefreshCurrentItem += RefreshItem;
        
        OnFinishGame += StartFinishGame;
        
        if (buttonReturnMenu != null)
            buttonReturnMenu.onClick.AddListener(() => SceneManager.LoadScene(sceneBuildIndex: 0));

        if (buttonPlay != null)
            buttonPlay.onClick.AddListener(() => SceneManager.LoadScene(sceneBuildIndex: 1));

        if (buttonReplay != null)
            buttonReplay.onClick.AddListener(() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex));
    }
    
    private void StartFinishGame()
    {
        StartCoroutine(FinishGame());
    }
    
    private IEnumerator FinishGame()
    {
        yield return new WaitForSeconds(3f); // Timepo que toma que termine la animacion de muerte
        
        panelStatistics.SetActive(true);

        finalStats.text = $"Monedas recogidas: {coins.text}" +
                          $"\nTiempo: {timer.text}s" +
                          $"\nDistancia recorrida: {distance.text}m";
    }

    private void OnEnable()
    {
        //OnRefreshCoins += RefreshCoins;
        //OnRefreshTimer += RefreshTimer;
        //OnRefreshLife += RefreshLife;
        //OnRefreshDistance += RefreshDistance;
//
//
        //OnRefreshCurrentItem += RefreshItem;
    }

    private void OnDisable()
    {
        OnRefreshCoins -= RefreshCoins;
        OnRefreshTimer -= RefreshTimer;
        OnRefreshLife -= RefreshLife;
        OnRefreshDistance -= RefreshDistance;

        OnFinishGame -= StartFinishGame;

        OnRefreshCurrentItem -= RefreshItem;
    }
}