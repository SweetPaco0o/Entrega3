using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal1Tp : MonoBehaviour
{
    public Transform teleportLocation; 
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("tP");
            other.transform.position = teleportLocation.position;
        }
    }
}