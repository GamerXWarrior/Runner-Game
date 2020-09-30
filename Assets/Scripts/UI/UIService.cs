using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIService : MonoGenericSingleton<UIService>
{
    public float startPos;
    public float finishPos;
    private float timer;
    private float time;
    private float hours;
    private float minutes;
    private float seconds;
    public TextMeshProUGUI distanceText;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI coinsText;
    private float distanceCount;
    private float timerCount;
    private float coinCount;
    private PlayerView player;
    public Button startButton;
    public Button pauseButton;
    private GameStates gameState;
    public Transform idlePlayer;
    public GameObject mainMenuUi;
    public GameObject gameUi;
    public PauseMenu pauseUi;
    public GameOverUi gameOverUi;
    public Vector3 camPos;

    protected override void Awake()
    {
        base.Awake();
    }

    protected override void Start()
    {
        base.Start();
        Camera.main.transform.position = camPos;
        EventService.Instance.PlayerSpawn += OnPlayerSpawned;
        EventService.Instance.PlayerDead += OnPlayerDead;
        idlePlayer.gameObject.SetActive(true);
        startButton.onClick.AddListener(() => StartGame());
        pauseButton.onClick.AddListener(() => OnPause());
        mainMenuUi.gameObject.SetActive(true);
    }

    private void StartGame()
    {

        PlayerService.Instance.StartGame();
    }

    public void OnPlayerSpawned()
    {
        Debug.Log("game chaalu");
        ChangeUi();
        timer = 0f;
        timerText.text = "Time: " + timer / 3600 + ":" + (timer % 3600) / 60 + ":" + (timer % 3600) % 60;
        player = PlayerService.Instance.GetCurrentPlayer();
        if (player != null)
        {
            startPos = PlayerService.Instance.GetPlayerSpawnPos();
            distanceText.text = "Dist: " + startPos;
        }
        else
        {
            Debug.Log("Player is null");
        }
        gameState = GameStates.Started;
        healthText.text = "" + HealthService.Instance.GetHealthCount();
    }

    private void ChangeUi()
    {
        mainMenuUi.gameObject.SetActive(false);
        idlePlayer.gameObject.SetActive(false);
        gameUi.gameObject.SetActive(true);
    }

    

    public void OnPlayerDead()
    {
        finishPos = PlayerService.Instance.GetPlayerFinishPos();
        gameState = GameStates.End;
        gameUi.gameObject.SetActive(false);
        gameOverUi.gameObject.SetActive(true);
        gameOverUi.SetResult(distanceCount, timer, coinCount);
    }

    public void UpdateHealthCount()
    {
        healthText.text = "" + HealthService.Instance.GetHealthCount();
    }
    public void UpdateCoinsCount()
    {
        coinCount++;
        coinsText.text = "" + coinCount;
    }

    private void OnPause()
    {
        pauseUi.gameObject.SetActive(true);
    }

    void Update()
    {
        if (gameState == GameStates.Started)
        {
            if (player != null)
            {
                distanceCount = Mathf.Floor(-player.transform.position.z);
                distanceText.text = "" + Mathf.Floor(distanceCount);

                timer += Time.deltaTime;
                hours = Mathf.Floor(timer / 3600);
                minutes = Mathf.Floor((timer % 3600) / 60);
                seconds = Mathf.Floor((timer % 3600) % 60);
                timerText.text = "" + hours + ":" + minutes + ":" + seconds;
            }
        }
    }
}
