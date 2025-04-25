using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionDeNiveles : MonoBehaviour
{
    [SerializeField] GameObject nivelExtra;
    public void VerificarAccesoNivelExtra()
    {
        int nivelExtraDesbloqueado = PlayerPrefs.GetInt("NivelExtraDesbloqueado", 0);

        if (nivelExtraDesbloqueado == 1) 
        {
            nivelExtra.SetActive(true);
        }
    }

    void Start()
    {
        VerificarAccesoNivelExtra();
    }
}
