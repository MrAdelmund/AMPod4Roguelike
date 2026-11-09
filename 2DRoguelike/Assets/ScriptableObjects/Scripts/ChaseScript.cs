using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseScript : MonoBehaviour
{
    public static List<ChaseScript> ActiveEnemies = new List<ChaseScript>();
    [Header("Stats")]
    public float maxHealth;
    public float health;
    public float moveSpeed;
    public float damage;
    private Rigidbody2D rb;
    public GameObject Player;
    
    
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        ActiveEnemies.Add(this);

    }
    private void OnDestroy()
    {
        ActiveEnemies.Remove(this);
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
