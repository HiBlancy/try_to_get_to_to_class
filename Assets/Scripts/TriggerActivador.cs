using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerActivador : MonoBehaviour
{
    public UnityEvent alActivar;
    public float retraso; // segundos de espera antes de activar

    private bool activado = false; // para evitar que se active más de una vez, opcional

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!activado && collision.CompareTag("Player"))
        {
            activado = true;
            StartCoroutine(ActivarConRetraso());
        }
    }

    private System.Collections.IEnumerator ActivarConRetraso()
    {
        yield return new WaitForSeconds(retraso);
        alActivar.Invoke();
    }
}
