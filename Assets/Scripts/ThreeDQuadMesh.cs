using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThreeDQuadMesh : MonoBehaviour
{
    private Mesh customMesh;

    // Start is called before the first frame update
    void Start()
    {
        Mesh newMesh = new Mesh();

        Vector3[] vertices = new Vector3[8];

        vertices[0] = new Vector3(.5f, -.5f, .5f);
        vertices[1] = new Vector3(.5f, .5f, .5f);
        vertices[2] = new Vector3(-.5f, .5f, .5f);
        vertices[3] = new Vector3(-.5f, -.5f, .5f);

        vertices[4] = new Vector3(.5f, -.5f, -.5f);
        vertices[5] = new Vector3(.5f, .5f, -.5f);
        vertices[6] = new Vector3(-.5f, .5f, -.5f);
        vertices[7] = new Vector3(-.5f, -.5f, -.5f);

        newMesh.vertices = vertices;

        int[] indices = new int[36];

        indices[0] = 0;
        indices[1] = 1;
        indices[2] = 2;
        indices[3] = 3;
        indices[4] = 0;
        indices[5] = 2;

        indices[6] = 6;
        indices[7] = 5;
        indices[8] = 4;
        indices[9] = 6;
        indices[10] = 4;
        indices[11] = 7;

        indices[12] = 2;
        indices[13] = 6;
        indices[14] = 3;
        indices[15] = 3;
        indices[16] = 6;
        indices[17] = 7;

        indices[18] = 1;
        indices[19] = 0;
        indices[20] = 4;
        indices[21] = 5;
        indices[22] = 1;
        indices[23] = 4;

        indices[24] = 1;
        indices[25] = 5;
        indices[26] = 2;
        indices[27] = 6;
        indices[28] = 2;
        indices[29] = 5;

        indices[30] = 3;
        indices[31] = 4;
        indices[32] = 0;
        indices[33] = 4;
        indices[34] = 3;
        indices[35] = 7;

        newMesh.triangles = indices;

        Vector3[] norms = new Vector3[8];

        for(int i = 0; i < norms.Length; i++)
        {
            norms[i] = -Vector3.forward;
        }

        newMesh.normals = norms;

        Vector2[] UVs = new Vector2[8];

        UVs[0] = new Vector2(.5f, .5f);
        UVs[1] = new Vector2(.5f, -.5f);
        UVs[2] = new Vector2(-.5f, .5f);
        UVs[3] = new Vector2(-.5f, -.5f);
        UVs[4] = new Vector2(0, 1);
        UVs[5] = new Vector2(1, 1);
        UVs[6] = new Vector2(0, 0);
        UVs[7] = new Vector2(1, 0);

        newMesh.uv = UVs;

        MeshFilter filter = GetComponent<MeshFilter>();
        filter.mesh = newMesh;
        customMesh = newMesh;
    }

    void OnDestroy()
    {
        if (customMesh != null)
        {
            Destroy(customMesh);
        }
    }
}
