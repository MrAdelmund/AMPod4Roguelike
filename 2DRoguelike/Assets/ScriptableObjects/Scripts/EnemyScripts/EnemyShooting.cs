using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject Projectile;
    public float AttackCD;
    public float AttackCDRate;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        AttackCDRate -= Time.deltaTime;
        ProjectileStuff();
        
    }
    void ProjectileStuff()
    {
        if(AttackCDRate <= 0)
        {
            Projectile.transform.position = transform.position;
            Instantiate(Projectile);
            AttackCDRate = 5;
        }
    }
}
