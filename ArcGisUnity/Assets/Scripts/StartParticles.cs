using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartParticles : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var part = GetComponent<ParticleSystem>();
        part.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
