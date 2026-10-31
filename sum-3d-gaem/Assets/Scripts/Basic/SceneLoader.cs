using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public static class SceneLoader
{

    public static IEnumerator LoadWithBootScreen(string currentSceneName, string nextSceneName)
    {
        LoadSceneAdditive("LoadingScreen");

        LoadSceneAdditive(nextSceneName);
        yield return new WaitForSeconds(3f);
        
        UnloadScene(currentSceneName);
        UnloadScene("LoadingScreen");
    }

    public static void LoadSceneAdditive(string sceneName)
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
    }

    public static void UnloadScene(string sceneName)
    {
        SceneManager.UnloadSceneAsync(sceneName);
    }
    

}
