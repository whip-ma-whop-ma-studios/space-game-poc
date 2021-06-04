using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField, Tooltip("GameObject camera should follow")]
    public Transform ObjectToFollow;
    [SerializeField, Tooltip("Speed to follow")]
    public float smoothSpeed = 0.1f;
    [SerializeField, Tooltip("Default camera offset")]
    public Vector3 offset = new Vector3(0, 0.5f, -10);
    [SerializeField, Tooltip("x coordinate of the left edge")]
    public float leftEdgeX = -10;
    [SerializeField, Tooltip("x coordinate of the right edge")]
    public float rightEdgeX = 17;

    void FixedUpdate()
    {
        Vector3 desiredPosition = ObjectToFollow.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        Debug.Log(ObjectToFollow.GetComponent<Rigidbody2D>().velocity);
    }

    public void Teleport(Vector3 toPosition)
    {
        var camToObjectX = transform.position.x - ObjectToFollow.position.x;
        var pos = transform.position;
        pos.x = toPosition.x + camToObjectX;
        transform.position = pos;
    }
}
