using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkManager : MonoBehaviour
{
    [SerializeField] private int seed = 42069;

    [SerializeField] float perlinOffset;
    
    // Start is called before the first frame update
    void Start()
    {
        Random.InitState(seed);

        perlinOffset = Random.value;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
