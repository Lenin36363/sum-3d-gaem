using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private Canvas canvasComp;
    private bool isPaused;

    void Start()
    {
        isPaused = false;
        if (canvasComp == null)
        {
            canvasComp = GetComponent<Canvas>();
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            canvasComp.enabled = !canvasComp.enabled;
            if (isPaused == false)
            {
                Time.timeScale = 0f;
                isPaused = true;
            }else if (isPaused == true){
                Time.timeScale = 1f;
                isPaused = false;
            }
        }
    }
}