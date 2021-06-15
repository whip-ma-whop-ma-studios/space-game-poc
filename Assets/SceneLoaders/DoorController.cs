using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorController : SceneLoader, IInteractableObj
{
    [SerializeField, Tooltip("Scene to go to")]
    public string _sceneToLoad;

    public void Interact()
    {
        Debug.Log("Going down!");
        LoadScene(_sceneToLoad);
    }
}
