using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverUi : MonoBehaviour
{
    public Button mainMenuButton;
    public TextMeshProUGUI totalDistanxce;
    public TextMeshProUGUI totalTime;
    public TextMeshProUGUI totalCoins;

    void Start()
    {
        mainMenuButton.onClick.AddListener(() => loadMainMenu());
    }

    private void OnEnable()
    {

    }

    public void SetResult(float dist, float timer, float coins)
    {
        SetDistance(dist);
        SetTime(timer);
        SetCoins(coins);
    }

    private void SetDistance(float dist)
    {
        totalDistanxce.text = "" + dist;
    }
    private void SetTime(float timer)
    {
        float hours = Mathf.Floor(timer / 3600);
        float minutes = Mathf.Floor((timer % 3600) / 60);
        float seconds = Mathf.Floor((timer % 3600) % 60);
        totalTime.text = "" + hours + ":" + minutes + ":" + seconds;
    }
    private void SetCoins(float coins)
    {
        totalCoins.text = "" + coins;
    }

    private void loadMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
