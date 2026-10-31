using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameIgnition : MonoBehaviour
{
    void Start()
    {
        SceneLoader.LoadSceneAdditive("Menu");
    }
}
