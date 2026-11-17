using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class v2weaponSO : MonoBehaviour
{
    /*

    [Header("References")]
    public WeaponInventory inventory;
    public Transform firePoint; // Where projectiles spawn (defaults to player position)

    // Tracks the next time each weapon is allowed to fire
    private Dictionary<WeaponSO, float> weaponCooldowns = new Dictionary<WeaponSO, float>();

    private void Update()
    {
        if (inventory == null) return;

        // Replace 'inventory.equippedWeapons' with whatever list/collection your WeaponInventory uses
        foreach (WeaponSO weapon in inventory.equippedWeapons)
        {
            if (weapon == null) continue;

            if (!weaponCooldowns.ContainsKey(weapon))
                weaponCooldowns[weapon] = 0f;

            if (Time.time >= weaponCooldowns[weapon])
            {
                FireWeapon(weapon);
                weaponCooldowns[weapon] = Time.time + (1f / weapon.fireRate);
            }
        }
    }

    private void FireWeapon(WeaponSO weapon)
    {
        if (weapon.projectilePrefab == null) return;

        Vector3 spawnPos = firePoint != null ? firePoint.position : transform.position;
        Vector2 baseDirection = GetAimDirection(); // Aim toward mouse or nearest enemy

        float baseAngle = Mathf.Atan2(baseDirection.y, baseDirection.x) * Mathf.Rad2Deg;

        for (int i = 0; i < weapon.projectileCount; i++)
        {
            float angleOffset = 0f;

            if (weapon.projectileCount > 1)
            {
                // Distributes projectiles evenly across the spreadAngle
                float step = weapon.spreadAngle / (weapon.projectileCount - 1);
                angleOffset = -weapon.spreadAngle / 2f + (step * i);
            }
           
            Quaternion rotation = Quaternion.Euler(0f, 0f, baseAngle + angleOffset);
            GameObject bullet = Instantiate(weapon.bulletPrefab, slot.position, Quaternion.identity);
           

            if (projObj.TryGetComponent(out Projectile projectile))
            {
                projectile.Initialize(weapon);
            }
        }
    }

    private Vector2 GetAimDirection()
    {
        // Example: Aim toward mouse position in 2D
        Vector3 mouseWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return (mouseWorld - transform.position).normalized;
    }
    */
}
