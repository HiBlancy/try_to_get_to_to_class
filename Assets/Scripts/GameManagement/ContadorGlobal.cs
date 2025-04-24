using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ContadorGlobal : MonoBehaviour
{
    public TMP_Text contadorGlobalText;  // Referencia al componente TextMeshPro

    void Start()
    {
        // Obtener el valor de muertes globales desde PlayerPrefs
        int muertesGlobal = PlayerPrefs.GetInt("MuertesGlobal", 0); // Si no existe, usará 0 como valor por defecto

        // Actualizar el texto con las muertes globales
        ActualizarTextoGlobal(muertesGlobal);
    }

    private void ActualizarTextoGlobal(int muertesGlobal)
    {
        if (contadorGlobalText != null)
        {
            // Mostrar el número de muertes en el UI
            contadorGlobalText.text = muertesGlobal.ToString();
        }
    }
}
