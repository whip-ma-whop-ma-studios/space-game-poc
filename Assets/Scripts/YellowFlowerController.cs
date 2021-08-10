using System.Collections.Generic;
using UnityEngine;

public class YellowFlowerController : Consumable, IInteractableObj
{
    // TODO Make Interactables be a member of many Objectives
    [SerializeField]
    public ObjectiveState _requiredState;
    [SerializeField]
    public Objective _relatedObjective;

    public void Interact()
    {
        Consume(-20);
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
