using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private CanvasGroup canvasGroup;
    private bool isPaused;

    public InputActionReference pauseAction;

    void Start()
    {
        pauseAction.action.Enable();
        isPaused = false;
        canvasGroup.alpha = 0f;
    }

    void Update()
    {
        if (pauseAction.action.WasPressedThisFrame())
        {
            if (isPaused == false)
            {
                Cursor.lockState = CursorLockMode.None;
                canvasGroup.alpha = 1f;
                Time.timeScale = 0f;
                isPaused = true;
            }else if (isPaused == true){
                Cursor.lockState = CursorLockMode.Locked;
                canvasGroup.alpha = 0f;
                Time.timeScale = 1f;
                isPaused = false;
            }
        }
    }

    public void Unpause()
    {
        if (isPaused == true){
            Cursor.lockState = CursorLockMode.Locked;
            canvasGroup.alpha = 0f;
            Time.timeScale = 1f;
            isPaused = false;
        }
    }

    
}