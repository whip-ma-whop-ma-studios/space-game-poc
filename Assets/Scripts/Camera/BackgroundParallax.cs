using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundParallax : MonoBehaviour
{
    [SerializeField, Tooltip("Amount to parallax")]
    private float _parallaxAmount = 0.2f;
    [SerializeField]
    private Camera _mainCamera;
    [SerializeField]
    private float _leftEdgeX = -26;
    [SerializeField]
    private GameObject _light;

    private float _length;
    private GameObject _leftClone, _rightClone;
    private float _lightDistanceFromBackground;

    void Start()
    {
        _length = GetComponent<SpriteRenderer>().bounds.size.x;

        _leftClone = Instantiate(gameObject);
        _leftClone.GetComponent<BackgroundParallax>().enabled = false;
        _rightClone = Instantiate(gameObject);
        _rightClone.GetComponent<BackgroundParallax>().enabled = false;

        if (_light != null)
        {
            // If there is a light on this background element, see how far from the centre of the following background element it is
            _lightDistanceFromBackground = _light.transform.position.x - transform.position.x;
        }
    }

    void Update()
    {
        float cameraMovedFromLeft = _mainCamera.transform.position.x - _leftEdgeX;
        float distToMove = cameraMovedFromLeft * _parallaxAmount;
        transform.position = new Vector3(_leftEdgeX + distToMove + (_length / 2), transform.position.y, transform.position.z);

        if (_light != null)
        {
            // If there is a light on this background element, move it in the x direction also
            _light.transform.position = new Vector3(transform.position.x + _lightDistanceFromBackground, _light.transform.position.y, _light.transform.position.z);
        }

        _leftClone.transform.position = transform.position - new Vector3(_length, 0, 0);
        _rightClone.transform.position = transform.position + new Vector3(_length, 0, 0);
    }
}
