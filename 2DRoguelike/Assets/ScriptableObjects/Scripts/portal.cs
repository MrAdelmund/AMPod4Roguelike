using UnityEngine;
using UnityEngine.SceneManagement;
public class portal : MonoBehaviour
{
    public WaveManager WaveManager;
    [SerializeField] private string SceneToLoad;
    private Vector2 targetCoordinates = new Vector2(0f, 0f);


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (SceneManager.GetActiveScene().name == "shop" )//|| !WaveManager.roundActive)
        {
            Debug.Log("I hit portal");
            if (other.CompareTag("Player"))
            {
                other.transform.position = new Vector3(targetCoordinates.x, targetCoordinates.y);


                Debug.Log("I enter portal");
                SceneManager.LoadScene(SceneToLoad);
            }
        }
    }

}
