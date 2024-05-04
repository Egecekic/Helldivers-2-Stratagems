using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SounEffectManager : MonoBehaviour
{
    public AudioClip CorrectSound,WrongSound;

    private AudioSource m_AudioSource;


    private void Awake()
    {
        m_AudioSource=GetComponent<AudioSource>();
    }

    public void CorretcEffect()
    {
        m_AudioSource.clip = CorrectSound;
        PlayEffectSound();
    }
    public void WrongeFfect()
    {
        m_AudioSource.clip = WrongSound;
        PlayEffectSound();
    }
    private void PlayEffectSound()
    {
        m_AudioSource.Play();
    }
}
