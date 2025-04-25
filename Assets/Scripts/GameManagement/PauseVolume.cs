using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseVolume : MonoBehaviour
{
    public Slider sliderMusica;
    public Slider sliderEfectos;

    [SerializeField] GameObject mainPausePanel;
    [SerializeField] GameObject optionsPausePanel;

    void Start()
    {
        // cargar volumenes guardados o usar por defecto
        float volumenMusica = PlayerPrefs.GetFloat("VolumenMusica", 1f);
        float volumenEfectos = PlayerPrefs.GetFloat("VolumenEfectos", 1f);

        sliderMusica.value = volumenMusica;
        sliderEfectos.value = volumenEfectos;

        // aplicar
        MusicManager.instance?.SetVolume(volumenMusica);
        AudioManager.obj?.SetVolume(volumenEfectos);

        // listeners
        sliderMusica.onValueChanged.AddListener(SetVolumenMusica);
        sliderEfectos.onValueChanged.AddListener(SetVolumenEfectos);
    }

    public void SetVolumenMusica(float valor)
    {
        MusicManager.instance?.SetVolume(valor);
        PlayerPrefs.SetFloat("VolumenMusica", valor);
    }

    public void SetVolumenEfectos(float valor)
    {
        AudioManager.obj?.SetVolume(valor);
        PlayerPrefs.SetFloat("VolumenEfectos", valor);
    }

    public void MainMenuPanel()
    {
        mainPausePanel.SetActive(true);
        optionsPausePanel.SetActive(false);
    }

    public void SettingsPanel()
    {
        optionsPausePanel.SetActive(true);
        mainPausePanel.SetActive(false);
    }
}
