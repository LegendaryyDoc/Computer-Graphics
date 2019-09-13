using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeOfDay : MonoBehaviour
{
    public Light sun;
    public Light moon;
    public float secondInDay = 120f;
    public float sunStartIntensity = 1f;
    public float moonStartIntensity = 1f;
    public float timeMultiplier = 1f;

    private float curTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        sun.intensity = sunStartIntensity;
        moon.intensity = moonStartIntensity;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateSun();
        UpdateMoon();

        curTime += (Time.deltaTime / secondInDay) * timeMultiplier;

        if(curTime >= 1)
        {
            curTime = 0;
        }
    }

    void UpdateSun()
    {
        sun.transform.localRotation = Quaternion.Euler((curTime * 360) - 90, 170, 0);

        float intensityMultiplier = 1;
        if(curTime <= 0.23f)
        {
            intensityMultiplier = 0;
        }
        else if(curTime <= .25f)
        {
            intensityMultiplier = Mathf.Clamp01((curTime - .23f) * (1 / .02f));
        }
        else if(curTime >= .73f)
        {
            intensityMultiplier = Mathf.Clamp01((curTime - .73f) * (1 / .02f));
        }

        sun.intensity = sunStartIntensity * intensityMultiplier;
    }

    void UpdateMoon()
    {
        moon.transform.localRotation = Quaternion.Euler((curTime * 360) - 270, 170, 0);

        float intensityMultiplier = 1;
        if (curTime <= 0.23f)
        {
            intensityMultiplier = 0;
        }
        else if (curTime <= .25f)
        {
            intensityMultiplier = Mathf.Clamp01((curTime - .23f) * (1 / .02f));
        }
        else if (curTime >= .73f)
        {
            intensityMultiplier = Mathf.Clamp01((curTime - .73f) * (1 / .02f));
        }

        moon.intensity = sunStartIntensity * intensityMultiplier;
    }
}
