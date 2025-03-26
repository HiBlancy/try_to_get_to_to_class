using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    [SerializeField] GameObject optionsPanel;
    static bool GamePaused = false;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GamePaused)
            {
                BackToGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void ResetLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void BackToGame()
    {
        Time.timeScale = 1f;
        optionsPanel.SetActive(false);
        GamePaused = false;
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        optionsPanel.SetActive(true);
        GamePaused = true;
    }
    public void MainMenuScene()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
