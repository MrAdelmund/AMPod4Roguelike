using UnityEngine;
using UnityEngine.SceneManagement;
public class portals : MonoBehaviour
{
    //public WaveManager WaveManager;
    [SerializeField] private string SceneToLoad;
    private Vector2 targetCoordinates = new Vector2(0f, 0f);


    private void OnTriggerEnter2D(Collider2D other)
    {
        //if (SceneManager.GetActiveScene().name == "shop" || !WaveManager.roundActive)
        // {
        EnemyBasics enemyBasics = other.GetComponent<EnemyBasics>();
        if (other.CompareTag("Player"))
        {
            other.transform.position = new Vector3(targetCoordinates.x, targetCoordinates.y);


           
            SceneManager.LoadScene(SceneToLoad);
        }
        // }
    }

}
