using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBasics : MonoBehaviour
{
    [SerializeField] ChaseScript EnemyStas;
    public float currentHealth;
    public GameObject xpOrbPrefab;
    public int xpValue = 1;
    public int goldValue = 1;
    private EnemyBehavior behavior;
    public GameObject goldOrbPrefab;
    [SerializeField] Projectile Proj;
    [SerializeField] ChaseScript EnemyStats;
    [HideInInspector] public GameObject GetPlayerObject() => player;
    private GameObject player;
    public static List<EnemyBasics> ActiveEnemies = new List<EnemyBasics>();
    // Start is called before the first frame update
    void Awake()
    {
        
        ActiveEnemies.Add(this);
        currentHealth = EnemyStas.maxHealth;
    }
    private void OnDestroy()
    {
        ActiveEnemies.Remove(this);
    }
    public void TakeDamage(float damage)
    {
        
        if (currentHealth <= 0f)
        {
            Die();
        }
        
    }
    void Die()
    {
        if (xpOrbPrefab != null)
        {
            Instantiate(
                xpOrbPrefab,
                (transform.position + new Vector3(Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f), 0)),
                Quaternion.identity
            );
        }
        // Drop Gold
        if (goldOrbPrefab != null)
            Instantiate(
                goldOrbPrefab,
                (transform.position + new Vector3(Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f), 0)),
                Quaternion.identity);

        

        Destroy(gameObject);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        
        PlayerStats player = other.GetComponent<PlayerStats>();

        if (player != null && behavior == null)
        {
            player.TakeDamage(EnemyStats.damage);
        }
    }
}
