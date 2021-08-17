using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundRotating : MonoBehaviour
{
    [SerializeField, Tooltip("x coordinate of the left edge")]
    public float _leftEdgeX = -10;
    [SerializeField, Tooltip("x coordinate of the right edge")]
    public float _rightEdgeX = 17;
    [SerializeField, Tooltip("The main camera")]
    public Camera _mainCamera;

    // Update is called once per frame
    void Update()
    {
        float cameraMovedFromLeft = Mathf.Abs(_leftEdgeX) + _mainCamera.transform.position.x;
        float percentageMoved = cameraMovedFromLeft / (Mathf.Abs(_leftEdgeX) + _rightEdgeX);
        float angleToRotate = 1 - (percentageMoved * 360);

        transform.position = new Vector3(_mainCamera.transform.position.x, transform.position.y, transform.position.z);
        transform.rotation = Quaternion.Euler(0, 0, angleToRotate);
    }
}
