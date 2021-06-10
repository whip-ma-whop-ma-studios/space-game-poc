using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedFlowerController : Consumable, IInteractableObj
{
    public void Interact()
    {
        Consume(10);
    }
}
