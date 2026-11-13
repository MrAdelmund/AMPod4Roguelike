using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameOverReturn : MonoBehaviour
{
    public static string lastSceneName = "MainScene";
    private InputAction escapeAction;
    void Awake()
    {
        escapeAction = new InputAction(type: InputActionType.Button, binding: "<Keyboard>/escape");
        escapeAction.performed += OnEscapePressed;
    }
    void OnEnable()
    {
        escapeAction.Enable();
    }
    void OnDisable()
    {
        escapeAction.Disable();
    }
    private void OnEscapePressed(InputAction.CallbackContext context)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(lastSceneName);
    }
    
}
