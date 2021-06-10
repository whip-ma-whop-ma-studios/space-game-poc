using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundParallax : MonoBehaviour
{
    [SerializeField, Tooltip("Amount to parallax")]
    float parallaxAmount = 0.2f;
    [SerializeField, Tooltip("The main camera")]
    public Camera mainCamera;
    [SerializeField, Tooltip("LeftEdge of map")]
    public float leftEdgeX = -26;

    private float _length;
    private GameObject _leftClone, _rightClone;

    // Start is called before the first frame update
    void Start()
    {
        _length = GetComponent<SpriteRenderer>().bounds.size.x;

        _leftClone = Instantiate(gameObject);
        _leftClone.GetComponent<BackgroundParallax>().enabled = false;
        _rightClone = Instantiate(gameObject);
        _rightClone.GetComponent<BackgroundParallax>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        float cameraMovedFromLeft = mainCamera.transform.position.x - leftEdgeX;
        float distToMove = cameraMovedFromLeft * parallaxAmount;
        transform.position = new Vector3(leftEdgeX + distToMove + (_length / 2), transform.position.y, transform.position.z);

        _leftClone.transform.position = transform.position - new Vector3(_length, 0, 0);
        _rightClone.transform.position = transform.position + new Vector3(_length, 0, 0);
    }

}
