using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWrapAroundController : MonoBehaviour
{
    [SerializeField, Tooltip("X coorodinate for left edge of the map")]
    float leftEdge = -10;
    [SerializeField, Tooltip("X coorodinate for right edge of the map")]
    float rightEdge = 17;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 pos = transform.position;
        var size = GetComponent<BoxCollider2D>().bounds.size;
        var halfWidth = size.x / 2;

        if (pos.x + halfWidth <= leftEdge)
        {
            pos.x = rightEdge - halfWidth;
        }
        else if (pos.x - halfWidth >= rightEdge)
        {
            pos.x = leftEdge + halfWidth;
        }

        transform.position = pos;
    }
}
