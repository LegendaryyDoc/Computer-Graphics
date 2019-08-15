using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOfDeath : MonoBehaviour
{
    public bool isAlive = true;
    public float fadeSpeed = 1;

    private Renderer rend;
    private Color curColor;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        curColor = rend.material.color;
    }

    // Update is called once per frame
    void Update()
    {
        if(isAlive == false)
        {
            if (curColor.a >= 0)
            {
                curColor.a -= fadeSpeed;
            }
            rend.material.color = curColor;
            Debug.Log(curColor.a);
        }
    }
}
