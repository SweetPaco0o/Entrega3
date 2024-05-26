using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeCode : MonoBehaviour
{
    public Slider slider;
    private const string volumeKey = "audioVolume";

    void Start()
    {
        // Cargar el valor guardado si existe, de lo contrario usar el valor por defecto (0.5)
        if (PlayerPrefs.HasKey(volumeKey))
        {
            slider.value = PlayerPrefs.GetFloat(volumeKey);
            Debug.Log("Valor del slider cargado: " + slider.value);
        }
        else
        {
            slider.value = 0.5f;
            Debug.Log("No se encontró un valor guardado. Usando valor por defecto: " + slider.value);
        }

        // Aplicar el valor del slider al volumen de audio
        AudioListener.volume = slider.value;

        // Agregar el listener al evento OnValueChanged
        slider.onValueChanged.AddListener(ChangeSlider);
        Debug.Log("Listener añadido al slider.");
    }

    void ChangeSlider(float value)
    {
        // Guardar el valor del slider y aplicarlo al volumen de audio
        PlayerPrefs.SetFloat(volumeKey, value);
        PlayerPrefs.Save(); // Asegura que el valor se guarde inmediatamente
        AudioListener.volume = value;
        Debug.Log("Valor del slider guardado y volumen de audio ajustado: " + value);
    }
}