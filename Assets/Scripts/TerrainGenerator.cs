using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    public Terrain terrain;
    public int terrainSize;
    float[,] heights;

    public float startScale;
    public float startZoom;
    public int octaves;

    public float octaveScale;
    public float octaveZoom;

    float scale;
    float zoom;

    // Start is called before the first frame update
    void Start()
    {
        heights = new float[terrainSize, terrainSize];
        scale = startScale;
        zoom = startZoom;

        GenerateHeights();
        UpdateTerrain();
    }

    void GenerateHeights()
    {
        for(int octave = 0; octave < octaves; octave++)
        {
            AddNoise();
            scale *= octaveScale;
            zoom *= octaveZoom;
        }
    }

    void AddNoise()
    {
        for(int x = 0; x<terrainSize; x++)
        {
            for(int y = 0; y<terrainSize; y++)
            {
                heights[x, y] += Mathf.PerlinNoise(x*zoom, y*zoom) * scale;
            }
        }
    }

    void UpdateTerrain()
    {
        terrain.terrainData.SetHeights(0, 0, heights);
    }
}
