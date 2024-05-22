using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleControllerFirelights : MonoBehaviour
{
    ParticleSystem particleSystem;

    private void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();
    }

    private void Update()
    {
        ChangeStrength();
        ChangeNoise();
    }

    private void ChangeNoise()
    {
        var noiseModule = particleSystem.noise;
        noiseModule.strength = Time.time;
    }

    private void ChangeStrength()
    {
        var emission = particleSystem.emission;
        emission.rateOverTime = (Mathf.Sin(Time.time) * 0.5f + 0.5f) * 50;

        var burst = emission.GetBurst(0);
        burst.count = 50;
        emission.SetBurst(0, burst);
    }
}
