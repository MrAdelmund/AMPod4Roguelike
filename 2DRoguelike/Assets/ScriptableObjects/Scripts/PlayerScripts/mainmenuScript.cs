
using UnityEngine;
using UnityEngine.SceneManagement;

public class v2mainmenus : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Quitgame()
    {
        Debug.Log("player quit application");
        Application.Quit();
    }

}
