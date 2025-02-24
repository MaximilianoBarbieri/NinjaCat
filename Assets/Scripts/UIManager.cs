using System;
using System.Net.Mime;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    //TODO: TIEMPO // DISTANCIA // COINS

    private LevelManager _levelManager => FindObjectOfType<LevelManager>();

    [SerializeField] private TextMeshPro timer;
    [SerializeField] private TextMeshPro coins;
    [SerializeField] private TextMeshPro distance;

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

    private void RefreshCoins(int value) => coins.text = $"{value}";
    private void RefreshTimer(float value) => timer.text = $"{value}";
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

        if (value <= 0)
            FinishGame();
    }

    private void FinishGame() => panelStatistics.SetActive(true);

    private void Start()
    {
        buttonReturnMenu.onClick.AddListener(() => SceneManager.LoadScene(sceneBuildIndex: 0));
        buttonPlay.onClick.AddListener(() => SceneManager.LoadScene(sceneBuildIndex: 1));

        buttonReplay.onClick.AddListener(() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex));
    }

    private void OnEnable()
    {
        OnRefreshCoins += RefreshCoins;
        OnRefreshTimer += RefreshTimer;
        OnRefreshLife += RefreshLife;
        OnRefreshDistance += RefreshDistance;

        OnRefreshCurrentItem += RefreshItem;
    }

    private void OnDisable()
    {
        OnRefreshCoins -= RefreshCoins;
        OnRefreshTimer -= RefreshTimer;
        OnRefreshLife -= RefreshLife;
        OnRefreshDistance -= RefreshDistance;

        OnRefreshCurrentItem -= RefreshItem;
    }
}