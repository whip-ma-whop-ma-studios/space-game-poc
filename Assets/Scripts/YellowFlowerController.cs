using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowFlowerController : Consumable, IInteractableObj
{
    public void Interact()
    {
        Consume(-20);
    }
}
