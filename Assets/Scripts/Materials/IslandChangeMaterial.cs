using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IslandChangeMaterial : MonoBehaviour // https://docs.unity3d.com/ScriptReference/TerrainData.SetAlphamaps.html used to understand the basics of terrain splat mapping
{
    public Terrain terrain; // gameobject assigning the material to

    // Start is called before the first frame update
    void Start()
    {
        float[,,] map = new float[terrain.terrainData.alphamapWidth, terrain.terrainData.alphamapHeight, terrain.terrainData.alphamapLayers];

        // need to go through all points on the alphamap
        for(int y = 0; y < terrain.terrainData.alphamapHeight; y++)
        {
            for(int x = 0; x < terrain.terrainData.alphamapWidth; x++)
            {
                // get normalized terrain coordinate
                float normX = x * 1.0f / (terrain.terrainData.alphamapWidth - 1);
                float normY = y * 1.0f / (terrain.terrainData.alphamapHeight - 1);

                // gets the angle at the normolized coordinate
                var angle = terrain.terrainData.GetSteepness(normX, normY);

                // need to get a range between 0 and 1 from the given angle
                var frac = angle / 90.0f;
                map[x, y, 0] = (float)frac;
                map[x, y, 1] = (float)(1 - frac);
            }
        }
        terrain.terrainData.SetAlphamaps(0, 0, map); // assigning the map just created to the terrain
    }
}