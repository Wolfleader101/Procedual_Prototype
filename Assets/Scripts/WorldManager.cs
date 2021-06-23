using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldManager : MonoBehaviour
{
    [SerializeField] private int worldSeed = 42069;
    [SerializeField] private GameObject player;

    [SerializeField] private int chunkSize = 128;
    [SerializeField] private int loadedGridSize = 3;

    [SerializeField] private Material grassMat;

    private float _perlinOffset;
    
    // Start is called before the first frame update
    void Start()
    {
        Random.InitState(worldSeed);

        _perlinOffset = Random.value;

        GenerateChunks();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void GenerateChunks()
    {
        // create grid of chunks
        int totalChunks = loadedGridSize * loadedGridSize;
        
        // get middle chunk which is where player should be
        int midChunk = (int)((float)totalChunks / 2 + 0.5);
        
        // create chunks from bottom left  going left to right

        // loop over row
        for (int row = 0, currentChunk = 1; row < loadedGridSize; row++)
        {
            // loop over col
            for (int col = 0; col < loadedGridSize; col++, currentChunk++)
            {
                if (currentChunk == midChunk)
                {
                    // Debug.Log("Mid Chunk");
                }
                //Debug.Log($"Row: {row} at col {col}, current chunk = {currentChunk}");
                
                CreateChunk(row, col,chunkSize * col, chunkSize * row);
            }
        }

    }

    void CreateChunk(int row, int col, int x, int z)
    {
        GameObject chunk = new GameObject($"Chunk {row}x{col}", typeof(MeshFilter), typeof(MeshRenderer), typeof(MeshCollider), typeof(ChunkManager));
        chunk.GetComponent<ChunkManager>().chunkSize = chunkSize;
        
        chunk.transform.localPosition = new Vector3(x, 0, z);

        chunk.GetComponent<MeshRenderer>().materials[0] = grassMat;
    }
}
