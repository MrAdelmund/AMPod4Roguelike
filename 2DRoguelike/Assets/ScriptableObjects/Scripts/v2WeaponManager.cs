using Packages.Rider.Editor.UnitTesting;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class v2WeaponManager : MonoBehaviour
{
    
    [SerializeField]
    public int projectileCount = 1;
    [SerializeField]
    private float projectileSpread;
   
    public float spreadAngle = 0f;

    [Header("References")]
    public WeaponInventory inventory;    // Reference to your existing WeaponInventory
    public List<Transform> weaponSlots;  // child transforms around player
    public GameObject bulletPrefab;
 
    private List<WeaponSO> equippedWeapons = new List<WeaponSO>();

    void Awake()
    {
        if (equippedWeapons != null && inventory.weapons != null)
        {
            equippedWeapons = inventory.weapons; // method you already have
                                                 // Assign sprites to slots
        }
        for (int i = 0; i < equippedWeapons.Count && i < weaponSlots.Count; i++)
        {
            WeaponSO weapon = equippedWeapons[i];
            Transform slot = weaponSlots[i];

            SpriteRenderer sr = slot.GetComponent<SpriteRenderer>();
            sr.sprite = weapon.sprite;
        }
    }

    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Vector3 mouseWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorld.z = 0f; // Ensures accurate 2D direction math 

        for (int i = 0; i < equippedWeapons.Count && i < weaponSlots.Count; i++)
        {
            WeaponSO weapon = equippedWeapons[i];
            Transform slot = weaponSlots[i];
            Vector2 direction = (mouseWorld - slot.position).normalized;

            // Rotate weapon sprite toward mouse 
            slot.up = direction;

            float angleStep =  projectileCount > 1 ? projectileSpread / (projectileCount - 1f) : 0f;
            float startAngle = projectileCount > 1 ? -projectileSpread / 2f : 0f;

            for (int j = 0; j < projectileCount; j++)
            {
                float currentAngle = slot.eulerAngles.z + startAngle + (angleStep * j);
                Quaternion spreadRotation = Quaternion.Euler(0f, 0f, currentAngle);

                // Instantiate with the spread rotation applied
                GameObject projectile = Instantiate(bulletPrefab, slot.position, spreadRotation);

                // Get Rigidbody2D and apply forward velocity along its individual rotated path
                Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
                if (rb != null)
                {
                    float projectileSpeed = 15f; // Replace with weapon.projectileSpeed if available
                    rb.velocity = projectile.transform.up * projectileSpeed;
                }
        if (projectile.TryGetComponent<Projectile>(out Projectile ProjectileScript))
                {
                    //  4 required parameters in Projectile.cs
                    ProjectileScript.Initialize(weapon.projectileSpeed, weapon.damage, weapon.projectileCount,  //weapon);   
                    weapon);
                }
                // projectile.transform.up points in the direction of spreadRotation
               
                }
            }
        }
    

    // Call this if inventory updates (player adds a weapon mid-game)
    public void RefreshWeapons()
    {
        equippedWeapons = inventory.weapons;

        for (int i = 0; i < weaponSlots.Count; i++)
        {
            SpriteRenderer sr = weaponSlots[i].GetComponent<SpriteRenderer>();
            if (i < equippedWeapons.Count)
            {
                sr.sprite = equippedWeapons[i].sprite;
            }
            else
            {
                sr.sprite = null;
            }
        }
    }
}

    

