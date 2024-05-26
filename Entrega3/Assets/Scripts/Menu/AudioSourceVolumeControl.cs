using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioSourceVolumeControl : MonoBehaviour
{
    public Slider volumeSlider; 
    public List<AudioSource> audioSources; 

    private const string volumeKey = "audioSourceVolume";

    void Start()
    {
        
        if (PlayerPrefs.HasKey(volumeKey))
        {
            volumeSlider.value = PlayerPrefs.GetFloat(volumeKey);
        }
        else
        {
            volumeSlider.value = 0.5f; 
        }

        
        foreach (AudioSource audioSource in audioSources)
        {
            audioSource.volume = volumeSlider.value;
        }

        
        volumeSlider.onValueChanged.AddListener(ChangeVolume);
    }

    void ChangeVolume(float value)
    {
        
        foreach (AudioSource audioSource in audioSources)
        {
            audioSource.volume = value;
        }

        
        PlayerPrefs.SetFloat(volumeKey, value);
        PlayerPrefs.Save(); 
    }
}