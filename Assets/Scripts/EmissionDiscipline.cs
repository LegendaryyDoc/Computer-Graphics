using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmissionDiscipline : MonoBehaviour
{
    public ParticleSystem emission;

    // Start is called before the first frame update
    void Start()
    {
        if(emission.isPlaying)
        {
            emission.Stop();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(emission == null)
        {
            return;
        }

        if(Input.GetMouseButtonDown(0))
        {
            emission.Play();
        }
        else if(Input.GetMouseButtonUp(0))
        {
            emission.Stop();
        }
    }
}