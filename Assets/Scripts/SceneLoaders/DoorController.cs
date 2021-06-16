using UnityEngine;

public class DoorController : SceneLoader, IInteractableObj
{
    [SerializeField]
    public string _sceneToLoad;

    public void Interact()
    {
        LoadScene(_sceneToLoad);
    }
}
