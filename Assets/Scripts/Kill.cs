using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kill : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            int muertesGlobal = PlayerPrefs.GetInt("MuertesGlobal", 0); // Obtén las muertes guardadas, si no hay se usa 0
            muertesGlobal++;  // Aumentamos las muertes globales

            // Guardar las muertes globales en PlayerPrefs
            PlayerPrefs.SetInt("MuertesGlobal", muertesGlobal);
            PlayerPrefs.Save(); // Asegúrate de guardar los cambios

            PauseGame.obj.ResetLevel();
        }
    }
}
