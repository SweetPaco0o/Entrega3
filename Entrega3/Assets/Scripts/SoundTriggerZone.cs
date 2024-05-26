using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTriggerZone : MonoBehaviour
{
    public AudioSource audioSource; 
    public AudioClip triggerSound; 

    void Start()
    {
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }

        if (audioSource != null && triggerSound != null)
        {
            audioSource.clip = triggerSound;
        }
        else
        {
            //Debug.LogWarning("AudioSource or TriggerSound is not assigned.");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlaySound();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StopSound();
        }
    }

    private void PlaySound()
    {
        if (audioSource != null && !audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }

    private void StopSound()
    {
        if (audioSource != null && audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }
}

