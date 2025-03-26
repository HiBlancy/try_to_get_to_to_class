using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManagement : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadSceneAsync("MainScene");
    }

    public void CloseGame()
    {
        Application.Quit();
    }
}
