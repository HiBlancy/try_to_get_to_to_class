using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Nivel : MonoBehaviour
{
    public int numeroNivelActual; // Ej: este es el nivel 3

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            CompletarNivel();
        }
    }

    void CompletarNivel()
    {
        int nivelMaxActual = PlayerPrefs.GetInt("NivelMaximoDesbloqueado", 1);

        // Solo actualiza si este nivel es el más alto jugado hasta ahora
        if (numeroNivelActual >= nivelMaxActual)
        {
            PlayerPrefs.SetInt("NivelMaximoDesbloqueado", numeroNivelActual + 1);
            PlayerPrefs.Save();
        }

        // Vuelve al menú o carga lo que quieras
        SceneManager.LoadScene("MainScene");
    }
}
