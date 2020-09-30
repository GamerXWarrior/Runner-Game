using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public Button resumeButton;
    public Button mainMenuButton;
    
    void Start()
    {
        
    }

    private void OnEnable()
    {
        Time.timeScale = 0;
        resumeButton.onClick.AddListener(() => resumeGame());
        mainMenuButton.onClick.AddListener(() => loadMainMenu());        
    }

    private void resumeGame()
    {
        Time.timeScale = 1;
        this.gameObject.SetActive(false);
    }

    private void loadMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
