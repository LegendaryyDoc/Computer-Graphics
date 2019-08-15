using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuadMesh : MonoBehaviour
{
    public float width = 1;
    public float height = 1;
    public Color curColor;
    public List<Texture> allTextures;
    public int textureNum = 0;

    private Mesh customMesh;
    private Renderer thisMat;
    private Color colorBefore;
    private int beforeNum;

    // Start is called before the first frame update
    void Start()
    {
        thisMat = GetComponent<Renderer>();
        curColor = thisMat.material.color;
        colorBefore = thisMat.material.color;
        beforeNum = textureNum;

        thisMat.material.mainTexture = allTextures[textureNum];

        Mesh newMesh = new Mesh();

        Vector3[] vertices = new Vector3[4];

        vertices[0] = new Vector3(width/2, height/2, 0);
        vertices[1] = new Vector3(-width/2, height/2, 0);
        vertices[2] = new Vector3(width/2, -height/2, 0);
        vertices[3] = new Vector3(-width/2, -height/2, 0);

        newMesh.vertices = vertices;

        int[] indices = new int[6];

        indices[0] = 0;
        indices[1] = 1;
        indices[2] = 2;
        indices[3] = 3;
        indices[4] = 2;
        indices[5] = 1;

        newMesh.triangles = indices;

        Vector3[] norms = new Vector3[4];

        for (int i = 0; i < norms.Length; i++)
        {
            norms[i] = -Vector3.forward;
        }

        newMesh.normals = norms;

        Vector2[] UVs = new Vector2[4];

        UVs[0] = new Vector2(1, 1);
        UVs[1] = new Vector2(0, 1);
        UVs[2] = new Vector2(1, 0);
        UVs[3] = new Vector2(0, 0);

        newMesh.uv = UVs;

        MeshFilter filter = GetComponent<MeshFilter>();
        filter.mesh = newMesh;
        customMesh = newMesh;
    }

    private void Update()
    {
        if (beforeNum != textureNum)
        {
            beforeNum = textureNum;
            thisMat.material.mainTexture = allTextures[textureNum];
        }

        if (curColor != colorBefore)
        {
            thisMat.material.color = curColor;
            colorBefore = curColor;
        }
    }

    void OnDestroy()
    {
        if (customMesh != null)
        {
            Destroy(customMesh);
        }
    }
}
