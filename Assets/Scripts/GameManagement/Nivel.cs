using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Nivel : MonoBehaviour
{
    public int numeroNivelActual;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(GanarConSonido());
        }
    }

    private IEnumerator GanarConSonido()
    {
        AudioManager.obj.playWin();

        float duracion = AudioManager.obj.kill.length;
        yield return new WaitForSeconds(duracion);

        CompletarNivel();
    }

    void CompletarNivel()
    {
        int nivelMaxActual = PlayerPrefs.GetInt("NivelMaximoDesbloqueado", 1);

        if (numeroNivelActual >= nivelMaxActual)
        {
            PlayerPrefs.SetInt("NivelMaximoDesbloqueado", numeroNivelActual + 1);
            PlayerPrefs.Save();
        }

        SceneManager.LoadScene("MainScene");
    }
}
