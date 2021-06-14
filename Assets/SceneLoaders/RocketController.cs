using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RocketController : SceneLoader, IInteractableObj
{
    [SerializeField, Tooltip("Scene to go to")]
    public string _sceneToLoad;

    public void Interact()
    {
        Debug.Log("Going up!");
        LoadScene(_sceneToLoad);
    }
}
