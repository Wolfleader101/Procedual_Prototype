using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkManager : MonoBehaviour
{
    public int chunkSize;
    
    public float chunkPosX;
    public float chunkPosZ;
    public float perlinOffset;
    public float heightScale = 4f;
    public float perlinNoiseScale = 0.04f;
    
    private Mesh _mesh;
    
    private Vector3[] _vertices;
    private int[] _triangles;
    
    void Start()
    {
        _mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = _mesh;
        
        CreateShape();
        UpdateMesh();
        
        GetComponent<MeshCollider>().sharedMesh = _mesh;
    }
    

    void CreateShape()
    {
        _vertices = new Vector3[(chunkSize + 1) * (chunkSize + 1)];


        for (int i = 0, z = 0; z <= chunkSize; z++)
        {
            for (int x = 0; x <= chunkSize; x++)
            {
                 float y = Mathf.PerlinNoise(
                     ((chunkSize * chunkPosX) + x) * perlinNoiseScale + perlinOffset,
                     ((chunkSize * chunkPosZ) + z) * perlinNoiseScale + perlinOffset) * heightScale;
                
                _vertices[i] = new Vector3(x, y, z);
                i++;
            }
        }

        _triangles = new int[chunkSize * chunkSize * 6];
        int vert = 0, tris = 0;
        for (int z = 0; z < chunkSize; z++)
        {
            for (int x = 0; x < chunkSize; x++)
            {
                _triangles[tris + 0] = vert + 0;
                _triangles[tris + 1] = vert + chunkSize + 1;
                _triangles[tris + 2] = vert + 1;
                _triangles[tris + 3] = vert + 1;
                _triangles[tris + 4] = vert + chunkSize + 1;
                _triangles[tris + 5] = vert + chunkSize + 2;

                vert++;
                tris += 6;
            }
           
            vert++;
        }
    }

    void UpdateMesh()
    {
        _mesh.Clear();

        _mesh.vertices = _vertices;
        _mesh.triangles = _triangles;

        _mesh.RecalculateNormals();
    }
    
}
