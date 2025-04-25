using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementoVisible : MonoBehaviour
{
    public GameObject[] objetosAparecer;

    public void AparecerObjetos()
    {
        foreach (var objeto in objetosAparecer)
        {
            objeto.SetActive(true);
        }
    }
}
