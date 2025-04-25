using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuNiveles : MonoBehaviour
{

    public Button[] botonesNiveles;
    public Sprite spriteBloqueado;
    public Sprite spriteDesbloqueado;

    void Start()
    {
        int maxNivel = PlayerPrefs.GetInt("NivelMaximoDesbloqueado", 1);

        for (int i = 0; i < botonesNiveles.Length; i++)
        {
            int nivel = i + 1;
            Button boton = botonesNiveles[i];
            Image imagenBoton = boton.GetComponent<Image>();
            TMP_Text textoBoton = boton.GetComponentInChildren<TMP_Text>();

            bool desbloqueado = nivel <= maxNivel;

            boton.interactable = desbloqueado;

            if (imagenBoton != null)
            {
                imagenBoton.sprite = desbloqueado ? spriteDesbloqueado : spriteBloqueado;
            }
        }
    }
}
