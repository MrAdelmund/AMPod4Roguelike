using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject Projectile;
    public float AttackCD;
    public float Attack;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Attack -= Time.deltaTime;
        ProjectileStuff();
        
    }
    void ProjectileStuff()
    {
        if(Attack <= 0)
        {
            Projectile.transform.position = transform.position;
            Instantiate(Projectile);
            Attack = AttackCD;
            
        }
    }
}
