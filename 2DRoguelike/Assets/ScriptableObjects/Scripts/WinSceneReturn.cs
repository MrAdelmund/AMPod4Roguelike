using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class WinSceneReturn : MonoBehaviour
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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
