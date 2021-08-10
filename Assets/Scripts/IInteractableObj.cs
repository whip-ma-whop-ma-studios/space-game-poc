using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractableObj
{
    public void Interact();
    public void CheckRequiredState();
    public void TransitionToNextState();
}
