using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedFlowerController : Consumable, IInteractableObj
{
    [SerializeField]
    public ObjectiveState _requiredState;
    [SerializeField]
    public Objective _relatedObjective;

    public void Interact()
    {
        Consume(10);
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
