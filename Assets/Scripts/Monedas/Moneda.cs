using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moneda : MonoBehaviour
{
    public int monedaNum;
    public int nivel;

    void Start()
    {
        if (PlayerPrefs.GetInt("MonedaNivel" + nivel + "_" + monedaNum) == 1)
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            AudioManager.obj.playPickUp();
            RecogerMoneda();
        }
    }

    private void RecogerMoneda()
    {
        PlayerPrefs.SetInt("MonedaNivel" + nivel + "_" + monedaNum, 1);
        PlayerPrefs.Save();

        gameObject.SetActive(false);

        ActualizarContadorMonedas();
    }

    private void ActualizarContadorMonedas()
    {
        int monedasRecogidas = PlayerPrefs.GetInt("MonedasRecogidas", 0);
        monedasRecogidas++;
        PlayerPrefs.SetInt("MonedasRecogidas", monedasRecogidas);
        PlayerPrefs.Save();

        VerificarNivelExtraDesbloqueado();
    }

    private void VerificarNivelExtraDesbloqueado()
    {
        int monedasRecogidas = PlayerPrefs.GetInt("MonedasRecogidas", 0);
        int monedasTotales = 33;
        //NIVEL 1 -> 9
        //NIVEL 2 -> 8
        //NIVEL 3 -> 3
        //NIVEL 4 -> 5
        //NIVEL 5 -> 1
        //NIVEL 6 -> 4
        //NIVEL 7 -> 2
        //TOTAL -> 33

        if (monedasRecogidas == monedasTotales)
        {
            DesbloquearNivelExtra();
        }
    }

    private void DesbloquearNivelExtra()
    {
        PlayerPrefs.SetInt("NivelExtraDesbloqueado", 1);
        PlayerPrefs.Save();
    }
}