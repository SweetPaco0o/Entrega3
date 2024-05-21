using UnityEngine;
using Cinemachine;
using System.Collections;
using System;

public class LeverController : MonoBehaviour
{
    public Animator Palanca; 
    public Animator Barrotes;
    public CinemachineVirtualCamera barrotesCam;

    void Start()
    {
        Palanca = GetComponent<Animator>();
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
    }

    private IEnumerator ActivateCameraWithDelay(float delayCamera)
    {
        yield return new WaitForSeconds(delayCamera);
        barrotesCam.Priority = 50;

        yield return new WaitForSeconds(2f); 
        barrotesCam.Priority = 1;
    }
}
