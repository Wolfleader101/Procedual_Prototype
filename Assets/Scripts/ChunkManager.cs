using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldManager : MonoBehaviour
{
    [SerializeField] private int worldSeed = 42069;

    [SerializeField] float perlinOffset;
    
    // Start is called before the first frame update
    void Start()
    {
        Random.InitState(worldSeed);

        perlinOffset = Random.value;
    }

    // Update is called once per frame
    void Update()
    {
    }
}
