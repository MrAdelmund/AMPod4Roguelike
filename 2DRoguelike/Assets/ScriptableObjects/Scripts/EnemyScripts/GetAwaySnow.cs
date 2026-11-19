using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GetAwaySnow : MonoBehaviour
{
    public GameObject Player;
    public float moveSpeed;
    public GameObject FindPoint;
    public bool AlreadySpawn;
    public bool IsClose;
    private Rigidbody2D rb;
    public float DetectionRange = 5;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Player = GameObject.FindGameObjectWithTag("Player");
        
    }
    
    // Update is called once per frame
    void Update()
    {
        
        GetawayFromPlay();
        
    }
    void GetawayFromPlay()
    {
        float distance = Vector3.Distance(this.transform.position, Player.transform.position);
        if (distance < DetectionRange && AlreadySpawn == false)
        {
            Instantiate(FindPoint);
            AlreadySpawn = true;
        }
    }
}
