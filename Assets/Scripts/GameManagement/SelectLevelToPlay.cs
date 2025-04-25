using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectLevelToPlay : MonoBehaviour
{
    public void ChargeFirstLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level1");
    }

    public void ChargeSecondLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level2");
    }
    public void ChargeThirdLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level3");
    }
    public void ChargeForthLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level4");
    }
    public void ChargeFifthLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level5");
    }
    public void ChargeSixthLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level6");
    }
    public void ChargeSevenLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level7");
    }
    public void ChargeEightLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level8");
    }
    public void ChargeNineLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level9");
    }
    public void ChargeTenLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level10");
    }
    public void ChargeExtraLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("LevelExtra");
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ResetearProgreso()
    {
        PlayerPrefs.DeleteKey("NivelMaximoDesbloqueado");
        PlayerPrefs.DeleteKey("MuertesGlobal");
        PlayerPrefs.DeleteKey("MonedasRecogidas");
        PlayerPrefs.SetInt("NivelExtraDesbloqueado", 0);

        int[] monedasPorNivel = new int[] { 9, 8}; // ejemplo

        for (int nivel = 1; nivel <= monedasPorNivel.Length; nivel++)
        {
            for (int num = 0; num < monedasPorNivel[nivel - 1]; num++)
            {
                PlayerPrefs.DeleteKey("MonedaNivel" + nivel + "_" + num);
            }
        }

        PlayerPrefs.Save();
        SceneManager.LoadScene("MainMenu");
    }
}