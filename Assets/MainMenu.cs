using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : SceneLoader
{
    [SerializeField, Tooltip("Scene to go to")]
    public string _sceneToLoad;

    public void StartGame()
    {
        LoadScene(_sceneToLoad);
    }
}
