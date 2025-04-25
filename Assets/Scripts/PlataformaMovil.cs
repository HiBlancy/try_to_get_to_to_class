using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaMovil : MonoBehaviour
{
    public enum EjeMovimiento { X, Y }

    public EjeMovimiento ejeMovimiento;
    public float distanciaMovimiento;
    public float velocidad;
    public float tiempoAVolver ;

    private Vector3 puntoInicial;
    private Vector3 puntoFinal;
    private bool mover = false;

    void Start()
    {
        puntoInicial = transform.position;

        CalcularPuntoFinal();
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
        StartCoroutine(MoverYRegresar());
    }

    private IEnumerator MoverYRegresar()
    {
        mover = true;

        while (transform.position != puntoFinal)
        {
            yield return null;
        }

        yield return new WaitForSeconds(tiempoAVolver);

        mover = false;
        StartCoroutine(MoverDeRegreso());
    }

    private IEnumerator MoverDeRegreso()
    {
        while (transform.position != puntoInicial)
        {
            transform.position = Vector3.MoveTowards(transform.position, puntoInicial, velocidad * Time.deltaTime);
            yield return null;
        }
    }

    private void CalcularPuntoFinal()
    {
        switch (ejeMovimiento)
        {
            case EjeMovimiento.X:
                puntoFinal = new Vector3(puntoInicial.x + distanciaMovimiento, puntoInicial.y, puntoInicial.z);
                break;
            case EjeMovimiento.Y:
                puntoFinal = new Vector3(puntoInicial.x, puntoInicial.y + distanciaMovimiento, puntoInicial.z);
                break;
        }
    }
}
