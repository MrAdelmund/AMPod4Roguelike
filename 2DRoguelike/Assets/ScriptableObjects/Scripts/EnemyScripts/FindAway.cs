using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindAway : MonoBehaviour
{
    
    Vector3 RandomSpawn;
    void Start()
    {
        float X = Random.Range(0, 11);
        float Y = Random.Range(0, 11);
        RandomSpawn.x = X;
        RandomSpawn.y = Y;
        transform.position = RandomSpawn;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
