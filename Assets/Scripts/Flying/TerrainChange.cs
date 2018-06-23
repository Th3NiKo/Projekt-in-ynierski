using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class TerrainChange : MonoBehaviour {
 
    public int width = 256;
    public int height = 256;
 
    public int depth = 20;
    public float scale = 20f;
 
 
    void Start () {
        Terrain terrain = GetComponent<Terrain>();
        terrain.terrainData = Generate(terrain.terrainData);       
    }
 
 
    TerrainData Generate(TerrainData terrainData){
        terrainData.heightmapResolution = width + 1;
        terrainData.size = new Vector3(width, depth, height);
        terrainData.SetHeights(0,0,GenerateHeights());
        return terrainData;
    }
 
    float[,] GenerateHeights(){
        float[,] heights = new float [width, height];
        for(int x = 0; x < width; x++){
            for(int y = 0; y < height; y++){
                heights[x,y] = CalculateHeight(x,y);
            }
        }
        return heights;
    }
 
    float CalculateHeight(float x, float y){
        float xCoord = (float)(x + this.transform.position.x) / width * scale;
        float yCoord = (float)(y + this.transform.position.z) / height * scale;
        float perlin = Mathf.PerlinNoise(xCoord, yCoord);
        return perlin;
    }
   
}