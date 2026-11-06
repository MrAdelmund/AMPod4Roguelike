using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaveManager : MonoBehaviour
{

    [Header("Wave Settings")]
    public float roundDuration = 30f;
    public int currentWave = 1;

    [Header("References")]
    public ShopManager shopManager;

    private float roundTimer;
    public int CooldownCORU = 10;
    public bool roundActive = true;
   
    private EnemySpawner spawner;
    
    void Start()
    {
        if (SceneManager.GetActiveScene().name != "shop")
        {
            spawner = gameObject.GetComponent<EnemySpawner>();
            Debug.Log("spawned");
        }

    }

    void Update()
    {

        if (SceneManager.GetActiveScene().name != "shop" && roundActive)
        {

            if (!roundActive) return;
            roundTimer += Time.deltaTime;

            if (roundTimer >= roundDuration && !spawner.boss)
            {
                EndRound();
                Debug.Log("end round");
                // Pause the game
                //Time.timeScale = 0f;


                //shopManager.OpenShop();
            }
        }
    }



    public void EndRound()
    {
        if (SceneManager.GetActiveScene().name != "shop")
        {
            roundActive = false;
            spawner.boss = false;

            // Clear all remaining enemies
            foreach (Enemy e in new System.Collections.Generic.List<Enemy>(Enemy.ActiveEnemies))
            {
                if (e != null)
                    Destroy(e.gameObject);
            }

            StartCorutineCooldown();
        }
    }
    private void StartCorutineCooldown()
    {
        StartCoroutine(CooldownCoroutine());
        Debug.Log("corutine start");
    }
    IEnumerator CooldownCoroutine()
    {
        roundActive = false;
        yield return new WaitForSeconds(CooldownCORU);
        roundActive = true;
        currentWave++;
    }
    public void OnShopClosed()
    {
        // Resume next round
        roundTimer = 0f;
        roundActive = true;
        currentWave++;
    }
   
}
