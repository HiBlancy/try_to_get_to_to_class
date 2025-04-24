using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaMovil : MonoBehaviour
{
    public Vector3 puntoFinal;
    public float velocidad = 2f;
    private bool mover = false;

    private Vector3 puntoInicial;

    void Start()
    {
        puntoInicial = transform.position;
    }

    void Update()
    {
        if (mover)
        {
            transform.position = Vector3.MoveTowards(transform.position, puntoFinal, velocidad * Time.deltaTime);
        }
    }

    public void Realizar()
    {
        mover = true;
    }
}
