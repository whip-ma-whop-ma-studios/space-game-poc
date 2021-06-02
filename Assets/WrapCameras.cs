using UnityEngine;
using UnityEngine.UI;

public class WrapCameras : MonoBehaviour
{
    [SerializeField, Tooltip("x coordinate of the left edge")]
    public float leftEdgeX = -10;
    [SerializeField, Tooltip("x coordinate of the right edge")]
    public float rightEdgeX = 17;
    [SerializeField, Tooltip("z coordinate to draw the side cubes on")]
    public float cubeLayerZ = 0.5f;
    [SerializeField, Tooltip("The main camera")]
    public Camera mainCamera;

    private Camera leftCamera;
    private Camera rightCamera;

    private GameObject leftCube;
    private GameObject rightCube;

    void Start()
    { 
        var cameraHeight = mainCamera.orthographicSize * 2f;
        var cameraWidth = cameraHeight * mainCamera.aspect;

        // Setup both cameras on each side
        leftCamera = CreateSideCamera("leftCamera", cameraHeight, new Vector3(leftEdgeX + (cameraHeight * mainCamera.aspect / 2), 0, -1));
        rightCamera = CreateSideCamera("rightCamera", cameraHeight, new Vector3(rightEdgeX - (cameraHeight * mainCamera.aspect / 2), 0, -1));

        // And create materials for the cube from the camera view
        var rightCameraMaterial = CreateSideCameraMaterial("right", rightCamera);
        var leftCameraMaterial = CreateSideCameraMaterial("left", leftCamera);

        // Create cube on the left, showing the camera on the right
        leftCube = CreateSideImageCube(
            "leftCameraCube",
            rightCameraMaterial,
            new Vector3(-(cameraHeight * mainCamera.aspect), -(mainCamera.orthographicSize * 2f), 0),
            new Vector3(leftEdgeX - (cameraWidth / 2), 0, cubeLayerZ)
            );

        // Create cube on the right, showing the camera on the left
        rightCube = CreateSideImageCube(
            "rightCameraCube",
            leftCameraMaterial,
            new Vector3(-(cameraHeight * mainCamera.aspect), -(mainCamera.orthographicSize * 2f), 0),
            new Vector3(rightEdgeX + (cameraWidth / 2), 0, cubeLayerZ)
            );
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 bottomLeftCameraEdge = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, mainCamera.nearClipPlane));
        Vector3 bottomRightCameraEdge = mainCamera.ViewportToWorldPoint(new Vector3(1, 0, mainCamera.nearClipPlane));
        Vector3 cameraPos = mainCamera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, mainCamera.nearClipPlane));

        if (bottomLeftCameraEdge.x <= leftEdgeX)
        {
            rightCamera.enabled = true;
            MoveCameraAndCubeUpDown(rightCamera, leftCube, mainCamera.transform.position.y);
        }
        else
        {
            rightCamera.enabled = false;
        }

        if (bottomRightCameraEdge.x >= rightEdgeX)
        {
            leftCamera.enabled = true;
            MoveCameraAndCubeUpDown(leftCamera, rightCube, mainCamera.transform.position.y);
        }
        else
        {
            leftCamera.enabled = false;
        }
    }

    Camera CreateSideCamera(string name, float cameraHeight, Vector3 position)
    {
        GameObject cameraObj = new GameObject();
        cameraObj.name = name;
        var camera = cameraObj.AddComponent<Camera>();
        camera.orthographic = true;
        // Orthographic camera width is 2*size
        camera.orthographicSize = mainCamera.orthographicSize;

        camera.transform.position = position;

        return camera;
    }

    Material CreateSideCameraMaterial(string name, Camera camera)
    {
        var rightCameraRT = new RenderTexture(camera.pixelWidth, camera.pixelHeight, 16, RenderTextureFormat.ARGB32);
        rightCameraRT.name = name + "RenderTexture";
        rightCameraRT.Create();

        camera.targetTexture = rightCameraRT;

        Material rightCameraMaterial = new Material(Shader.Find("Unlit/Texture"));
        rightCameraMaterial.SetTexture("_MainTex", rightCameraRT);
        rightCameraMaterial.name = name + "TextureMaterial";

        return rightCameraMaterial;
    }

    GameObject CreateSideImageCube(string name, Material material, Vector3 scale, Vector3 position)
    {
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.name = name;
        cube.GetComponent<Renderer>().material = material;
        cube.transform.localScale = scale;
        cube.transform.position = position;
        cube.GetComponent<BoxCollider>().enabled = false;

        return cube;
    }

    void MoveCameraAndCubeUpDown(Camera camera, GameObject cube, float y)
    {
        camera.transform.position = new Vector3(camera.transform.position.x, y, camera.transform.position.z);
        cube.transform.position = new Vector3(cube.transform.position.x, y, cube.transform.position.z);
    }
}
