using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Kill : MonoBehaviour
{
    public GameObject explosionEffect;
    public GameObject player;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SpriteRenderer playerRenderer = player.GetComponent<SpriteRenderer>();
            if (playerRenderer != null)
            {
                playerRenderer.enabled = false;
            }

            AudioManager.obj.playKill();

            GameObject explosion = Instantiate(explosionEffect, transform.position, Quaternion.identity);

            ParticleSystem ps = explosion.GetComponent<ParticleSystem>();

            ps.Play();

            int muertesGlobal = PlayerPrefs.GetInt("MuertesGlobal", 0);
            muertesGlobal++;
            PlayerPrefs.SetInt("MuertesGlobal", muertesGlobal);
            PlayerPrefs.Save();

            StartCoroutine(ReiniciarConSonido());
        }
    }

    private IEnumerator ReiniciarConSonido()
    {
        AudioManager.obj.playKill();

        float duracion = AudioManager.obj.kill.length;
        yield return new WaitForSeconds(duracion);

        PauseGame.obj.ResetLevel();
    }
}
