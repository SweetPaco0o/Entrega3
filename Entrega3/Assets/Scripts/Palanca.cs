using UnityEngine;
using Cinemachine;
using System.Collections;

public class LeverController : MonoBehaviour
{
    public Animator Palanca; 
    public Animator Barrotes;
    public CinemachineVirtualCamera barrotesCam;
    public AudioSource audioSource;
    public AudioClip barrotesSound; 

    void Start()
    {
        Palanca = GetComponent<Animator>();
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Palanca.SetBool("ActivarPalanca", true);

            StartCoroutine(ActivateBarrotesAnimationWithDelay(2f));
            StartCoroutine(ActivateCameraWithDelay(0.8f));
        }
    }

    private IEnumerator ActivateBarrotesAnimationWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Barrotes.SetBool("UnlockBarrotes", true);
        PlayBarrotesSound();
    }

    private IEnumerator ActivateCameraWithDelay(float delayCamera)
    {
        yield return new WaitForSeconds(delayCamera);
        barrotesCam.Priority = 50;

        yield return new WaitForSeconds(2f); 
        barrotesCam.Priority = 1;
    }

    private void PlayBarrotesSound()
    {
        if (audioSource != null && barrotesSound != null)
        {
            audioSource.clip = barrotesSound;
            audioSource.Play();
        }
        else
        {
            Debug.LogWarning("AudioSource or BarrotesSound is not assigned.");
        }
    }
}
