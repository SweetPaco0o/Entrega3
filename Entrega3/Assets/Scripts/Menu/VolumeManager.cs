/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeCode : MonoBehaviour
{
    public Slider slider;

    void Start()
    {
        slider.value = PlayerPrefs.GetFloat("audioVolume", 0.5f);
        AudioListener.volume = slider.value;
    }

    public void ChangeSlider()
    {
        PlayerPrefs.SetFloat("audioVolume", slider.value);
        AudioListener.volume = slider.value;
    }
}*/
