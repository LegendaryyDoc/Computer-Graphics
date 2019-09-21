using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovementBetween : MonoBehaviour
{
    public Camera mainCamera;
    public Camera overHeadCamera;
    public Canvas mainCanvas;
    public CanvasGroup cg;
    public float fadeSpeed; // controls how fast the fade happens

    private bool shouldFade; // controls if the fadeOut should go

    private void Start()
    {
        mainCamera.enabled = true;
        overHeadCamera.enabled = false;
    }
    private void Update()
    {
         if (cg.alpha.Equals(1) && shouldFade == true)
        {
            shouldFade = false;
            mainCamera.enabled = !mainCamera.isActiveAndEnabled; // setting cameras enabled to its opposite
            overHeadCamera.enabled = !overHeadCamera.isActiveAndEnabled;
            FadeOut();
        }
    }

    public void ChangeCamera() // for the button click
    {
        if (cg.alpha.Equals(0))
        {
            shouldFade = true;
            FadeIn();
        }

       
    }
    public IEnumerator Fade(CanvasGroup group, float speed, float alphaGoingTo) // lerp function for the fade
    {
        float start = Time.time;
        float timePast = Time.time - start;
        float perc = timePast / speed;

        while(true)
        {
            timePast = Time.time - start;
            perc = timePast / speed;

            float curAlpha = Mathf.Lerp(group.alpha, alphaGoingTo, perc);

            group.alpha = curAlpha;

            if (perc >= 1) break;

            yield return new WaitForEndOfFrame(); // makes it act like an update function
        }
    }
    public void FadeIn()
    {
        StartCoroutine(Fade(cg, fadeSpeed, 1));
    }
    public void FadeOut()
    {
        StartCoroutine(Fade(cg, fadeSpeed, 0));
    }
}