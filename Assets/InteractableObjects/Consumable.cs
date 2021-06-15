using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consumable : MonoBehaviour
{
    public void Consume(float healthValue)
    {
        Debug.Log("You ate it, got " + healthValue + " health!");
        gameObject.SetActive(false);
    }
}
