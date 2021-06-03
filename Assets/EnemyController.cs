using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField, Tooltip("Max speed, in units per second, that the character moves.")]
    float speed = 3;

    // Start is called before the first frame update
    void Start()
    {

    }


    void Update()
    {
        Vector3 pos = transform.position;

        if (Input.GetKey("."))
        {
            pos.x += speed * Time.deltaTime;
        }
        if (Input.GetKey(","))
        {
            pos.x -= speed * Time.deltaTime;
        }

        transform.position = pos;
    }

}
