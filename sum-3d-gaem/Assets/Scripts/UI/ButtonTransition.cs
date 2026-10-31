using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonTransition : MonoBehaviour
{
    [SerializeField] string nextSceneName;
    [SerializeField] string currentSceneName;
    public void LoadNewScene()
    {
        if (Time.timeScale == 0f){ Time.timeScale = 1f; }
        StartCoroutine(SceneLoader.LoadWithBootScreen(currentSceneName, nextSceneName));
    }

    public void ExitGame()
    {
        Debug.Log("Игра закроется... обещаю");
        Application.Quit();
    }
}
