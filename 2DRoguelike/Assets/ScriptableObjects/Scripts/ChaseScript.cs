using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseScript : MonoBehaviour
{
    [Header("Stats")]
    public float maxHealth;
    public float moveSpeed;
    public float damage;
    private Rigidbody2D rb;
    public GameObject Player;
    
    
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }
    
    // Update is called once per frame
    void Update()
    {
        Vector2 direction = (Player.transform.position - transform.position).normalized;
        rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);
        
    }
    
}
