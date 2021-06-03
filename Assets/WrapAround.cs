using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrapAround : MonoBehaviour
{
    public float leftEdge = -10;
    public float rightEdge = 17;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;

        if (pos.x <= leftEdge)
        {
            pos.x = rightEdge;
        }
        else if (pos.x >= rightEdge)
        {
            pos.x = leftEdge;
        }

        transform.position = pos;
    }
}
