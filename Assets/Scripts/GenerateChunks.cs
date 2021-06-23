using System;
using UnityEngine;


public class GenerateChunks : MonoBehaviour
{

    [SerializeField] private GameObject chunk;
    [SerializeField] private int chunkSize = 10;

    private GameObject[] _chunks;
    private void Start()
    {
        Generate();
    }

    void Generate()
    {
        _chunks = new GameObject[chunkSize];
        
        for (int i = 0; i < chunkSize; i++)
        {
            Mesh mesh = new Mesh();
           // Vector3[] vertices = new Vector3[] { };
            //int[] triangles = new int[] { };
            Vector3 pos = new Vector3();
            pos.x = transform.position.x + 100 * i;

            _chunks[i] = Instantiate(chunk, pos, new Quaternion(), transform);
            _chunks[i].GetComponent<MeshFilter>().mesh = mesh;

            //CreateShape(vertices, triangles);
            //UpdateMesh(mesh, vertices, triangles);
    
            _chunks[i].GetComponent<MeshCollider>().sharedMesh = mesh;
        }
    }
}