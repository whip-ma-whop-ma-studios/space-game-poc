using UnityEngine;

public class DoorController : SceneLoader, IInteractableObj
{
    [SerializeField]
    public ObjectiveState _requiredState;
    [SerializeField]
    public Objective _relatedObjective;

    [SerializeField]
    public string _sceneToLoad;

    public void Interact()
    {
        CheckRequiredState();
    }

    public void CheckRequiredState()
    {
        if (_relatedObjective != null && _requiredState != null)
        {
            // Check is state is valid
            if (_relatedObjective._currentState == _requiredState)
            {
                Debug.Log("Completed current part of quest!");
                LoadScene(_sceneToLoad);
            } else
            {
                Debug.Log("Cannot use this! There are quest steps to complete!");
            }

        }
    }
    public void TransitionToNextState()
    {
        if (_relatedObjective != null)
        {
            _relatedObjective.IncrementState();
        }
    }
}
