using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField, Tooltip("GameObject camera should follow")]
    public Transform ObjectToFollow;
    [SerializeField, Tooltip("Speed to follow")]
    public float smoothSpeed = 0.1f;
    [SerializeField, Tooltip("Default camera offset")]
    public Vector3 offset = new Vector3(0, 0.5f, -10);
    [SerializeField, Tooltip("Min camera size")]
    public float minCameraSize = 1;
    [SerializeField, Tooltip("Max camera size")]
    public float maxCameraSize = 3;
    [SerializeField, Tooltip("How fast to zoom")]
    public float zoomSpeed = 1;
    [SerializeField, Tooltip("x coordinate of the left edge")]
    public float leftEdgeX = -10;
    [SerializeField, Tooltip("x coordinate of the right edge")]
    public float rightEdgeX = 17;

    private Camera _cam;

    void Start()
    {
        _cam = GetComponent<Camera>();
    }

    void FixedUpdate()
    {
        Vector3 desiredPosition = ObjectToFollow.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        var xCameraObjectDiff = Mathf.Abs(desiredPosition.x - transform.position.x);

        _cam.orthographicSize = Mathf.Lerp(minCameraSize, maxCameraSize, xCameraObjectDiff * zoomSpeed);

        transform.position = smoothedPosition;       
    }

    public void Teleport(Vector3 toPosition)
    {
        var camToObjectX = transform.position.x - ObjectToFollow.position.x;
        var pos = transform.position;
        pos.x = toPosition.x + camToObjectX;
        transform.position = pos;
    }
}
