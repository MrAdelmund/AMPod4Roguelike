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
        rb = GetComponent<Rigidbody2D>();
        

    }
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = (Player.transform.position - transform.position).normalized;
        rb.MovePosition(rb.position + direction * Speed * Time.fixedDeltaTime);
    }

}
