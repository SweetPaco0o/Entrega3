using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal1Tp : MonoBehaviour
{
    public Transform teleportLocation; 
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("tP");
            SceneManager.LoadScene("Candy land");
        }
    }
}