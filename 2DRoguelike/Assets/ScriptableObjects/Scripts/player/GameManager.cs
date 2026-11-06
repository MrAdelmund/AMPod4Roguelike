using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PlayerClassSO startingClass;
    public PlayerStats playerStats;
    public WeaponController weaponController;
    public WeaponInventory playerInventory;
    public static GameManager instance;
  
    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        playerStats.Initialize(startingClass);
        // Add the starting weapon to the player's inventory
        playerInventory.AddWeapon(startingClass.startingWeapon);

    }
}
