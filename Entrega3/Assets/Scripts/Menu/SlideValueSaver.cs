using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderValueSaver : MonoBehaviour
{
    public Slider slider;

    void Start()
    {
        // Cargar el valor guardado si existe, de lo contrario usar el valor actual del slider
        if (PlayerPrefs.HasKey("SliderValue"))
        {
            slider.value = PlayerPrefs.GetFloat("SliderValue");
        }

        // Agregar el listener al evento OnValueChanged
        slider.onValueChanged.AddListener(SaveSliderValue);
    }

    public void SaveSliderValue(float value)
    {
        PlayerPrefs.SetFloat("SliderValue", value);
        PlayerPrefs.Save(); // Asegura que el valor se guarde inmediatamente
    }
}

