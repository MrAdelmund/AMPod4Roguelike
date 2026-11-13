
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    [Header("ui panels")]
    public GameObject mainmenupanel;
    public GameObject ClassSelectPanel;
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Quitgame()
    {
        Debug.Log("player quit application");
        Application.Quit();
    }

    public void openclassmenu()
    {
        mainmenupanel.SetActive(false);
        ClassSelectPanel.SetActive(true);
    }

    public void closeclassmenu()
    {
        mainmenupanel.SetActive(true);
        ClassSelectPanel.SetActive(false);
    }
    public static PlayerClassSO SelectedClass;
    public void SelectClass(PlayerClassSO chosenClass)
    {
        SelectedClass = chosenClass;
        Debug.Log("selected Class" + chosenClass.className);
        closeclassmenu();
    }
   

}

