using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(MeshFilter))]
public class MeshGenerator : MonoBehaviour
{
    [SerializeField] private int xSize = 20;
    [SerializeField] private int zSize = 20;

    [SerializeField] private float heightScale = 4f;
    [SerializeField] private float perlinNoiseScale = 0.3f;
    [SerializeField] private float perlinNoiseOffsetX = 100f;
    [SerializeField] private float perlinNoiseOffsetY = 100f;

    private Mesh _mesh;
    
    private Vector3[] _vertices;
    private int[] _triangles;


    /* Plans for procedural generation
     *
     * Procedurally generated biomes including blending between biomes and biomes props (e.g trees)
     * Procedurally generated Land-heights for biomes,
       e.g jungle might more level variation while open-fields are flat
     * Add in oceans, lakes and rivers
     * A preset seed count??
     * 
     */


    void Start()
    {
        _mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = _mesh;
        
        GeneratePerlinOffset();
        
        CreateShape();
        UpdateMesh();
        
        GetComponent<MeshCollider>().sharedMesh = _mesh;
    }

    // used for testing in scene
    void Update()
    {
         CreateShape();
         UpdateMesh();
    }
    

    void CreateShape()
    {
        _vertices = new Vector3[(xSize + 1) * (zSize + 1)];


        for (int i = 0, z = 0; z <= zSize; z++)
        {
            for (int x = 0; x <= xSize; x++)
            {
                float y = Mathf.PerlinNoise(x * perlinNoiseScale + perlinNoiseOffsetX,
                    z * perlinNoiseScale + perlinNoiseOffsetY) * heightScale;
                
                _vertices[i] = new Vector3(x, y, z);
                i++;
            }
        }

        _triangles = new int[xSize * zSize * 6];
        int vert = 0, tris = 0;
        for (int z = 0; z < zSize; z++)
        {
            for (int x = 0; x < xSize; x++)
            {
                _triangles[tris + 0] = vert + 0;
                _triangles[tris + 1] = vert + xSize + 1;
                _triangles[tris + 2] = vert + 1;
                _triangles[tris + 3] = vert + 1;
                _triangles[tris + 4] = vert + xSize + 1;
                _triangles[tris + 5] = vert + xSize + 2;

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

    void GeneratePerlinOffset()
    {
        perlinNoiseOffsetX = Random.Range(0f, 9999f);
        perlinNoiseOffsetY = Random.Range(0f, 9999f);
    }


    private void OnDrawGizmos()
    {
       if (_vertices == null) return;

         // for (int i = 0; i < _vertices.Length; i++)
         // {
         //     Gizmos.color = Color.red;
         //     if (i % 5 == 0)
         //     {
         //         Gizmos.DrawSphere(_vertices[i], 0.1f);
         //     }
         // }
    }
}