
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainmenuScript : MonoBehaviour
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
