using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerActivador : MonoBehaviour
{
    public UnityEvent alActivar;
    public float retraso;
    public int vecesParaActivar;

    private int contadorActivaciones = 0;
    private bool yaActivado = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!yaActivado && collision.CompareTag("Player"))
        {
            contadorActivaciones++;

            if (contadorActivaciones >= vecesParaActivar)
            {
                yaActivado = true;
                StartCoroutine(ActivarConRetraso());
            }
        }
    }

    private System.Collections.IEnumerator ActivarConRetraso()
    {
        yield return new WaitForSeconds(retraso);
        alActivar.Invoke();
    }
}
