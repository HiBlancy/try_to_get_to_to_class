using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaMovil : MonoBehaviour
{
    public enum EjeMovimiento { X, Y }

    [Header("Configuración de Movimiento")]
    public EjeMovimiento ejeMovimiento;
    public float distanciaMovimiento;
    public float velocidad;
    public float tiempoAVolver;

    [Header("Opciones de Regreso")]
    public bool debeVolver = true;
    public float velocidadVuelta = 2f;

    private Vector3 puntoInicial;
    private Vector3 puntoFinal;
    private bool enMovimiento = false;



    public void Realizar()
    {
        puntoInicial = transform.position;
        CalcularPuntoFinal();
        if (enMovimiento) return; // Evita superposición de movimientos

        StopAllCoroutines();
        StartCoroutine(MoverHaciaDestino());
    }

    private IEnumerator MoverHaciaDestino()
    {
        enMovimiento = true;

        // Mover hacia el puntoFinal (siempre la misma dirección)
        yield return StartCoroutine(Mover(puntoFinal, velocidad));

        if (debeVolver)
        {
            yield return new WaitForSeconds(tiempoAVolver);
            yield return StartCoroutine(Mover(puntoInicial, velocidadVuelta));
        }

        enMovimiento = false;
    }

    private IEnumerator Mover(Vector3 destino, float vel)
    {
        while (Vector3.Distance(transform.position, destino) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(transform.position, destino, vel * Time.deltaTime);
            yield return null;
        }
        transform.position = destino;
    }

    private void CalcularPuntoFinal()
    {
        switch (ejeMovimiento)
        {
            case EjeMovimiento.X:
                puntoFinal = puntoInicial + Vector3.right * distanciaMovimiento;
                break;
            case EjeMovimiento.Y:
                puntoFinal = puntoInicial + Vector3.up * distanciaMovimiento;
                break;
        }
    }
}
