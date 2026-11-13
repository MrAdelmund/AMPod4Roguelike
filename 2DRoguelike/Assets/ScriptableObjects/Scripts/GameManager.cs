using UnityEngine;

public class GameManager : MonoBehaviour
{
    public string selectedClass = "scout"; //defult
    public static GameManager Instance { get; private set; }
    public PlayerClassSO startingClass;
    public PlayerStats playerStats;
    public WeaponController weaponController;
    public WeaponInventory playerInventory;
    public PlayerClassSO SelectedClass { get; set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        playerStats.Initialize(startingClass);
        // Add the starting weapon to the player's inventory
        playerInventory.AddWeapon(startingClass.startingWeapon);

    }
    // public void SelectClasses(string className);
   
}
