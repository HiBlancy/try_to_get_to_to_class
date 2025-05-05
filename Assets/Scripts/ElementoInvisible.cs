using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementoInvisible : MonoBehaviour
{
    public GameObject[] objetosDesaparecer;

    public void DesaparecerparecerObjetos()
    {
        foreach (var objeto in objetosDesaparecer)
        {
            objeto.SetActive(false);
        }
    }
}
