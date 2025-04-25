using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManagement : MonoBehaviour
{
    [SerializeField] GameObject mainPanel;
    [SerializeField] GameObject optionsPanel;

    public void Play()
    {
        SceneManager.LoadSceneAsync("MainScene");
    }

    public void CloseGame()
    {
        Application.Quit();
    }

    public void MainMenuPanel()
    {
        mainPanel.SetActive(true);
        optionsPanel.SetActive(false);
    }

    public void SettingsPanel()
    {
        optionsPanel.SetActive(true);
        mainPanel.SetActive(false);
    }
}
