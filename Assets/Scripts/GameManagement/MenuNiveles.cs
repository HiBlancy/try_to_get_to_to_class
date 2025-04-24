using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuNiveles : MonoBehaviour
{

    public Button[] botonesNiveles; // Asigna en el inspector

    void Start()
    {
        int maxNivel = PlayerPrefs.GetInt("NivelMaximoDesbloqueado", 1);

        for (int i = 0; i < botonesNiveles.Length; i++)
        {
            int nivel = i + 1;
            botonesNiveles[i].interactable = nivel <= maxNivel;

            if (nivel > maxNivel)
            {
                botonesNiveles[i].GetComponentInChildren<TMP_Text>().text = "Bloqueado";
                botonesNiveles[i].image.color = Color.gray;
            }
        }
    }
}
