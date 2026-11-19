using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOver : MonoBehaviour
{

    public void ToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void Restart()
    {
        Debug.Log("Gameover");
        SceneManager.LoadScene("MainScene");
    }



}
