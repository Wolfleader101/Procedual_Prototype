using UnityEngine;

namespace DefaultNamespace
{
    public class GenerateChunks : MonoBehaviour
    {
        // void GenerateLand()
        // {
        //     _chunks = new GameObject[chunkSize];
        //
        //     // create 10 chunks
        //     for (int i = 0; i < chunkSize; i++)
        //     {
        //         Mesh mesh = new Mesh();
        //         Vector3[] vertices = new Vector3[] { };
        //         int[] triangles = new int[] { };
        //
        //         _chunks[i] = new GameObject($"Chunk{i}");
        //         _chunks[i].AddComponent<MeshFilter>();
        //         _chunks[i].AddComponent<MeshRenderer>();
        //         _chunks[i].AddComponent<MeshCollider>();
        //         _chunks[i].GetComponent<MeshFilter>().mesh = mesh;
        //         _chunks[i].GetComponent<MeshRenderer>().materials[0] = material;
        //
        //         CreateShape(vertices, triangles);
        //         UpdateMesh(mesh, vertices, triangles);
        //
        //         _chunks[i].GetComponent<MeshCollider>().sharedMesh = mesh;
        //     }
        // }
    }
}