using UnityEngine;

public class DoorController : SceneLoader, IInteractableObj
{
    [SerializeField]
    public CollectionQuest _requiredCompletedQuest;

    [SerializeField]
    public string _sceneToLoad;

    public void Interact(GameObject interactor)
    {
        CheckRequiredState();
    }

    public void CheckRequiredState()
    {
        if (_requiredCompletedQuest.IsFinsihed())
        {
            Debug.Log("Completed current part of quest!");
            LoadScene(_sceneToLoad);
        }
    }

}
