using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ContadorGlobal : MonoBehaviour
{
    public TMP_Text contadorMuertesGlobalText;
    public TMP_Text contadorMonedasGlobalText;

    void Start()
    {
        int muertesGlobal = PlayerPrefs.GetInt("MuertesGlobal", 0);
        int numeroMonedas = PlayerPrefs.GetInt("MonedasRecogidas", 0);

        ActualizarTextoGlobal(muertesGlobal, numeroMonedas);
    }

    private void ActualizarTextoGlobal(int muertesGlobal, int numeroMonedas)
    {
        if (contadorMuertesGlobalText != null)
        {
            contadorMuertesGlobalText.text = muertesGlobal.ToString();
        }

        if (contadorMonedasGlobalText != null)
        {
            contadorMonedasGlobalText.text = numeroMonedas.ToString();

        }
    }
}
