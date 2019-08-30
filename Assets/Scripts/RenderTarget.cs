using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderTarget : MonoBehaviour
{
    public RenderTexture rt;
    public GameObject obj;

    // Start is called before the first frame update
    void Start()
    {
        Graphics.SetRenderTarget(rt, 0, CubemapFace.Unknown, 0);
    }
}
