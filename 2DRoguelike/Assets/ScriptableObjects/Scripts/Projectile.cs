using System;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.UIElements;

public class Projectile : MonoBehaviour
{
    public float damage;
    private float speed;
    private float range;
    private int pirceCount;
    private float homingStrength;
    private Vector2 startPosition;
    private bool isDestroying = false;
    public bool isHoming;
    private Transform target;
    private Rigidbody2D rb;

     void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Initialize(float finalDamage, float projectileSpeed, float range, WeaponSO stats)
    {
        this.damage = stats.damage;
        this.speed = stats.projectileSpeed;
        this.range = stats.range;
        this.isHoming = stats.isHoming;
        this.homingStrength = stats.homingStrength;
        startPosition = transform.position;
        Destroy(gameObject, stats.range / stats.projectileSpeed);
        //GetComponent<Rigidbody2D>().velocity = direction.normalized * speed;

        if (isHoming)
        {
            FindNearbyTarget();
        }
    }

    void Update()
    {
        if (Vector2.Distance(startPosition, transform.position) >= range)
        {
            Destroy(gameObject);
        }
    }
    void FixedUpdate()
    {
        if (isHoming && target != null)
        {
            Vector2 direction = (Vector2)target.position - rb.position;
            direction.Normalize();
            float RotateAmount = Vector3.Cross(direction, transform.up).z;
            rb.angularVelocity = -RotateAmount * homingStrength * 200f;
        }
        rb.velocity = transform.up * speed;
    }
     private void FindNearbyTarget()
    {
        // looks for the tags or layers
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float closestDistance = Mathf.Infinity;
        Transform closetEnemy = null;
        foreach ( GameObject enemy in enemies)
        {
            float distance = Vector2.Distance(transform.position, enemy.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closetEnemy = enemy.transform;
            }
        }
        target = closetEnemy;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        EnemyBasics enemy = other.GetComponent<EnemyBasics>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);

            this.pirceCount--;
            
        }
        if (pirceCount <= 0)
        {
            isDestroying = true;
            Destroy(gameObject);
        }
    }

    internal void Initialize(float finalDamage, float projectileSpeed, float range, Vector2 dir)
    {
        throw new NotImplementedException();
    }

    internal void Initialize(float finalDamage, float projectileSpeed)
    {
        throw new NotImplementedException();
    }
}
