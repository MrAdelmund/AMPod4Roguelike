using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityUtils;
using static UnityEditor.Experimental.GraphView.GraphView;
public class EnemyWaves : MonoBehaviour
{
    
    [Header("Wave Info")]

    public float Scaling;
    public float WaveAmount;
    public bool WaveActive;

    [Header("Spawn Settings")]
    public float spawnRate = 1f;
    public float spawnRadius = 10f;

    [Header("Enemy Info")]
    public GameObject BasicEnemy;
    // Normal enemy basically the common slime
    public float NEnemy;
    // Anything other then a Basic enemy, like Shielders, Snowman ETC.
    public float UEnemy;
    [SerializeField] private ChaseScript EnemyStats;
    public Sprite[] SpriteList;
    public Vector3 SpawnTHingya;
    GameObject Player;

    [Header("References")]
    public GameObject player;
    public Transform[] EnemySpawns;
    public Transform spawnPos;

    // Start is called before the first frame update
    void Start()
    {
        WaveAmount = 1;
        Player = GameObject.FindGameObjectWithTag("Player");
        
    }
    void nextWave()
    {

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemies.Length <= 0 && WaveActive == false)
        {

            WaveAmount = WaveAmount + 1;

            for (int i = 0; i < 25; i++)
            {
                int R = Random.Range(1, 101);
                if (R < 81)
                {
                    NEnemy = NEnemy + 1;
                }
                else
                {
                    if (R >= 81)
                    {
                        UEnemy = UEnemy + 1;
                    }
                }
            }
            WaveActive = true;

        }

    }
    // Update is called once per frame
    void Update()
    {
        spawnRate -= Time.deltaTime;
        
        nextWave();
        SpawnInWave();
    }
    void SpawnInWave()
    {

        if (WaveActive == true && spawnRate <=0 && SceneManager.GetActiveScene().name != "shop")
        {
            

            GameObject currentPlayer = GameObject.FindGameObjectWithTag("Player");

            int R = Random.Range(1, 101);
            if (R < 81 && NEnemy > 0)
            {
                
                EnemyStats.maxHealth = 100f;
                EnemyStats.moveSpeed = 2f;
                EnemyStats.Edamage = 10f;
                int f = Random.Range(0, EnemySpawns.Length);
                GameObject e = Instantiate(BasicEnemy, EnemySpawns[f].position, Quaternion.identity);
                //e.GetComponent<Transform>().position = spawnPos[1];
                e.GetComponent<SpriteRenderer>().color = Color.white;
                //you need to change the index below in SpriteList[] to be the number you want. For example, if you have 10 waves and 10 different sprites, you can do based on the wave #
                e.GetComponent<SpriteRenderer>().sprite = SpriteList[0];
                
                NEnemy = NEnemy - 1;
                spawnRate = 1;
            }
            else
            {
                if (R >= 81 && UEnemy > 0)
                {
                    EnemyStats.maxHealth = 130f;
                    EnemyStats.moveSpeed = 1.5f;
                    EnemyStats.Edamage = 15f;
                    int f = Random.Range(0, EnemySpawns.Length);
                    GameObject e = Instantiate(BasicEnemy, EnemySpawns[f].position, Quaternion.identity);
                    e.GetComponent<SpriteRenderer>().color = Color.white;
                    e.GetComponent<SpriteRenderer>().sprite = SpriteList[1];

                    UEnemy = UEnemy - 1;
                    spawnRate = 1.5f;
                }
            }
            
        }

    }
    
      
}
