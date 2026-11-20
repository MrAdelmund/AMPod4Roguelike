using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.OnScreen.OnScreenStick;

public class EnemyProjectile : MonoBehaviour
{
    private Rigidbody2D rb;
    public GameObject Player;
    public float Projdamage;
    private EnemyBehavior behavior;
    public float Speed;
    public float TimeBeforeDestroy;
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
        Destroy(gameObject, TimeBeforeDestroy);
        

    }

    // Update is called once per frame
    void Update()
    {
       
    }
    private void OnTriggerEnter(Collider other)
    {
        PlayerStats player = other.GetComponent<PlayerStats>();

        if (gameObject.tag == "Player")
        {
            player.currentHealth -= Projdamage;
        }
    }
}
