using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode, ImageEffectAllowedInSceneView]
public class UnderwaterEffect : MonoBehaviour
{
    public Material mat;

    [Range(0.001f, 0.1f)]
    public float pixelOffset;
    [Range(0.2f, 20f)]
    public float noiseScale;
    [Range(0.2f, 20f)]
    public float noiseFrequency;
    [Range(0.2f, 30f)]
    public float noiseSpeed;

    // Update is called once per frame
    void Update()
    {
        mat.SetFloat("_NoiseFrequency", noiseFrequency);
        mat.SetFloat("_NoiseSpeed", noiseSpeed);
        mat.SetFloat("_NoiseScale", noiseScale);
        mat.SetFloat("_PixelOffset", pixelOffset);
    }

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        Graphics.Blit(source, destination, mat);
    }
}
