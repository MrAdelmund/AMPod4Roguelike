using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    private Rigidbody2D rb;
    public GameObject Player;
    public float damage;
    public float Speed;
    
    // Start is called before the first frame update
    private void Awake()
    {
        
        

    }
    void Start()

    {
        rb = GetComponent<Rigidbody2D>();
        Player = GameObject.FindGameObjectWithTag("Player");
        Vector2 direction = (Player.transform.position - transform.position).normalized;
        rb.velocity = (direction).normalized * Speed;
        
        

    }

    // Update is called once per frame
    void Update()
    {
       
    }

}
