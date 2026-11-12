using UnityEngine;

[CreateAssetMenu(menuName = "Roguelite/Weapon")]
public class WeaponSO : ScriptableObject
{
    [Header("Identity")]
    public string weaponName;
    public Sprite sprite;

    [Header("Combat Stats")]
    public float damage = 10f;
    public float fireRate = 1f; // shots per second
    public float projectileSpeed = 10f;
    public float range = 5f;
    [Range (0f, 1f)]
    public float critChance = 0.1f;
    public float critmultiplier = 1.5f;

    [Header("behavior & pattern")]
    //public WeaponAttackType attackType;
    public int projectileCount = 1;
    public float spreadAngle = 0f;

    [Header("projectile modifiers")]
    
    public int pirceCount = 1;
    public bool isHoming = false;
    public float homingStrength = 5f;
    public bool bounces = false;
    public int maxbounces = 2;

    [Header("Prefabs")]
    public Projectile projectilePrefab;

    public float GetFinalDamage(out bool isCrit)
    {
        isCrit = Random.value <= critChance;
        // the ? is a if statment and : is the else statment
        return isCrit ? damage * critmultiplier : damage;
    }
}
