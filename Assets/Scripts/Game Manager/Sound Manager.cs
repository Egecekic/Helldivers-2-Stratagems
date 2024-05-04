using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public List<AudioClip> clipList=new List<AudioClip>();
    AudioSource audioSource;

    public Slider volumeSlider;
    public float Volum;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        MusicPlay();
    }

    // Update is called once per frame
    void Update()
    {
        if (!audioSource.isPlaying)
        {
            MusicPlay(); // Yeni þarkýyý çal
        }
        setSoundValue();
    }
    void MusicPlay()
    {
        int x =Random.Range(0,clipList.Count);
        audioSource.clip = clipList[x];
        audioSource.Play();
    }
    public void setSoundValue()
    {
        audioSource.volume = volumeSlider.value;
    }
}
