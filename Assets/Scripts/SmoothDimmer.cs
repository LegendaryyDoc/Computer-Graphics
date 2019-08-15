using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SmoothDimmer : MonoBehaviour
{
    public float startIntensity = 0;
    public float endIntensity = 5;
    public float changeSpeed = .5f;

    private float curIntensity;
    private Light transitionLight;

    // Start is called before the first frame update
    void Start()
    {
        transitionLight = GetComponent<Light>();
        transitionLight.intensity = startIntensity;
        curIntensity = startIntensity;
    }

    // Update is called once per frame
    void Update()
    {
        while(curIntensity < endIntensity)
        {
            transitionLight.intensity += changeSpeed;
        }
    }
}
