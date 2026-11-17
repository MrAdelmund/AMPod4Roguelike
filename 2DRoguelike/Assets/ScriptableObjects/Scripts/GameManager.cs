using UnityEngine;

public class GameManager : MonoBehaviour
{
    public string selectedClass = "scout"; //defult
    public static GameManager Instance { get; private set; }
    public PlayerClassSO startingClass;
    public PlayerStats playerStats;
    public WeaponController weaponController;
    public WeaponInventory playerInventory;
    public PlayerClassSO SelectedClass { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        if (MainMenuScript.SelectedClass != null)
        {
            SelectedClass = MainMenuScript.SelectedClass;
        }
        else
        {
            Debug.Log("class not work");
            //selectedClass = PlayerClassSO.defultClass;
        }
    }
    void Start()
    {
        playerStats.Initialize(SelectedClass);
        // Add the starting weapon to the player's inventory
        playerInventory.AddWeapon(SelectedClass.startingWeapon);

    }

}
