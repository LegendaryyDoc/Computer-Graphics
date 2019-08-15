using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PentaMesh : MonoBehaviour
{
    private Mesh customMesh;

    void Start()
    {
        // First, let's create a new mesh
        var mesh = new Mesh();

        // Vertices
        // locations of vertices
        var verts = new Vector3[15];

        verts[0] = new Vector3(0, 0, 0);
        verts[1] = new Vector3(0, 1, 0);
        verts[2] = new Vector3(1, 0, 0);
        verts[3] = new Vector3(0, 0, 0);
        verts[4] = new Vector3(0, 1, 0);
        verts[5] = new Vector3(-1, 0, 0);
        verts[6] = new Vector3(0, 0, 0);
        verts[7] = new Vector3(-1, 0, 0);
        verts[8] = new Vector3(-1, -1, 0);
        verts[9] = new Vector3(0, 0, 0);
        verts[10] = new Vector3(-1, -1, 0);
        verts[11] = new Vector3(1, -1, 0);
        verts[12] = new Vector3(0, 0, 0);
        verts[13] = new Vector3(1, 0, 0);
        verts[14] = new Vector3(1, -1, 0);

        mesh.vertices = verts;

        // Indices
        // determines which vertices make up an individual triangle
        //
        // this should always be a multiple of three
        //
        // each triangle should be specified in _clock-wise_ order
        var indices = new int[15];

        indices[0] = 0;
        indices[1] = 2;
        indices[2] = 1;
        indices[3] = 3;
        indices[4] = 4;
        indices[5] = 5;
        indices[6] = 6;
        indices[7] = 7;
        indices[8] = 8;
        indices[9] = 9;
        indices[10] = 10;
        indices[11] = 11;
        indices[12] = 12;
        indices[13] = 14;
        indices[14] = 13;

        mesh.triangles = indices;

        // Normals
        // describes how light bounces off the surface (at the vertex level)
        //
        // note that this data is interpolated across the surface of the triangle
        var norms = new Vector3[15];

        for (int i = 0; i < norms.Length; i++)
        {
            norms[i] = -Vector3.forward;
        }

        mesh.normals = norms;

        // UVs, STs
        // defines how textures are mapped onto the surface
        var UVs = new Vector2[15];

        UVs[0] = new Vector2(0, 0);
        UVs[1] = new Vector2(0, 1);
        UVs[2] = new Vector2(1, 0);
        UVs[3] = new Vector2(0, 0);
        UVs[4] = new Vector2(0, 1);
        UVs[5] = new Vector2(-1, 0);
        UVs[6] = new Vector2(0, 0);
        UVs[7] = new Vector2(-1, 0);
        UVs[8] = new Vector2(-1, -1);
        UVs[9] = new Vector2(-1, -1);
        UVs[10] = new Vector2(-1, -1);
        UVs[11] = new Vector2(1, -1);
        UVs[12] = new Vector2(0, 0);
        UVs[13] = new Vector2(1, 0);
        UVs[14] = new Vector2(1, -1);
        
        mesh.uv = UVs;

        var filter = GetComponent<MeshFilter>();
        filter.mesh = mesh;
        customMesh = mesh;
    }

    void OnDestroy()
    {
        if (customMesh != null)
        {
            Destroy(customMesh);
        }
    }
}
