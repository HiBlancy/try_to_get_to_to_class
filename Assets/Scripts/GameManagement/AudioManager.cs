using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager obj { get; private set; }

    private float volumenEfectos = 1f;

    public AudioClip kill;
    [SerializeField] AudioClip pickUp;
    public AudioClip win;

    AudioSource audioSource;

    void Awake()
    {
        if (obj != null && obj != this)
            Destroy(this);
        else
            obj = this;

        audioSource = GetComponent<AudioSource>();
    }
    
    public void playKill()
    {
        playSound(kill);
    }
    public void playPickUp()
    {
        playSound(pickUp);
    }

    public void playWin()
    {
        playSound(win);
    }

    public void playSound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip, volumenEfectos);
    }

    public void SetVolume(float valor)
    {
        volumenEfectos = valor;
        audioSource.volume = volumenEfectos;
    }
}
