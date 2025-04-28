using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{
    public static PauseGame obj { get; private set; }

    [SerializeField] GameObject optionsPanel;
    static bool GamePaused = false;
    void Awake()
    {
        if (obj != null && obj != this)
            Destroy(this);
        else
            obj = this;
    }

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
                Pause();
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

    public void Pause()
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
