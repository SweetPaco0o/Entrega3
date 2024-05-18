using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ChestParticleController : MonoBehaviour
{
    public Transform _player;

    public ParticleSystem _particleSystem;

    public Color newColor;

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        _particleSystem = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, _player.position);
        
        if(distance < 7.5)
        {
            OpenChestParticles();
        }

    }

    private void OpenChestParticles()
    {
        
    }
}
