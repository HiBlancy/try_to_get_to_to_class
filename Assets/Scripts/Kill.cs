using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Kill : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            AudioManager.obj.playKill();
            int muertesGlobal = PlayerPrefs.GetInt("MuertesGlobal", 0);
            muertesGlobal++;

            PlayerPrefs.SetInt("MuertesGlobal", muertesGlobal);
            PlayerPrefs.Save();

            StartCoroutine(ReiniciarConSonido());
        }
    }

    private IEnumerator ReiniciarConSonido()
    {
        AudioManager.obj.playKill();

        float duracion = AudioManager.obj.kill.length;
        yield return new WaitForSeconds(duracion);

        PauseGame.obj.ResetLevel();
    }
}
