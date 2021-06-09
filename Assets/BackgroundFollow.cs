using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundFollow : MonoBehaviour
{
    [SerializeField, Tooltip("The main camera")]
    public Camera mainCamera;
    [SerializeField, Tooltip("x coordinate of the left edge")]
    public float leftEdgeX = -10;
    [SerializeField, Tooltip("x coordinate of the right edge")]
    public float rightEdgeX = 17;
    [SerializeField, Tooltip("Default offset from camera")]
    public Vector3 offset = new Vector3(0, 0.5f, 30);

    // Start is called before the first frame update
    void Start()
    {
        var pos = transform.position;
        pos = mainCamera.transform.position + offset;
        transform.position = pos;
        transform.eulerAngles = new Vector3(0, 0, GetAngle(mainCamera.transform.position.x));

    }

    // Update is called once per frame
    void Update()
    {
        var pos = transform.position;
        pos.x = mainCamera.transform.position.x;
        transform.position = pos;
        //transform.Rotate(new Vector3(0, 0, GetAngle(mainCamera.transform.position.x)));
        //transform.rotation = Quaternion.Euler(Vector3.forward * GetAngle(mainCamera.transform.position.x));
        Debug.Log("Angle: " + GetAngle(mainCamera.transform.position.x));
        transform.eulerAngles = new Vector3(0,0,GetAngle(mainCamera.transform.position.x));
    }

    float GetAngle(float cameraX)
    {
        var worldLength = Mathf.Abs(leftEdgeX) + Mathf.Abs(rightEdgeX);
        var distanceFromLeft = cameraX / worldLength;
        return 360 * distanceFromLeft;
    }
}
