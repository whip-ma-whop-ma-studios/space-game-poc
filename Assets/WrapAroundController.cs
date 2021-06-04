using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrapAroundController : MonoBehaviour
{
    [SerializeField, Tooltip("X coorodinate for left edge of the map")]
    float leftEdge = -10;
    [SerializeField, Tooltip("X coorodinate for right edge of the map")]
    float rightEdge = 17;

    public GameObject camera;

    private bool startedTeleporting = false;
    private GameObject clone;
    private Vector3 clonePos;

    void Update()
    {
        Vector3 pos = transform.position;
                
        var size = GetComponent<BoxCollider2D>().bounds.size;
        var halfWidth = size.x / 2;
        var objectLeftX = pos.x - halfWidth;
        var objectRightX = pos.x + halfWidth;

        if (!startedTeleporting && (IsTeleportingLeft(objectLeftX, objectRightX) || IsTeleportingRight(objectLeftX, objectRightX)))
        {
            // Start teleporting
            startedTeleporting = true;
            clone = Instantiate(gameObject, clonePos, Quaternion.identity);
            clone.GetComponent<WrapAroundController>().enabled = false;
            Physics2D.IgnoreCollision(clone.GetComponent<Collider2D>(), gameObject.GetComponent<Collider2D>(), true);
        }

        if (startedTeleporting) { 
            // Set clones location
            if (objectLeftX <= leftEdge)
            {
                var overlap = leftEdge - pos.x;
                clonePos = new Vector3(rightEdge - overlap, pos.y, pos.z);
            }
            else if (objectRightX >= rightEdge)
            {
                var overlap = pos.x - rightEdge;
                clonePos = new Vector3(leftEdge + overlap, pos.y, pos.z);
            }
            // And move it
            clone.transform.position = clonePos;

            // Check if we should actually teleport the object
            if (objectRightX <= leftEdge)
            {
                pos.x = GetXToTeleportLeft(objectLeftX, objectRightX, halfWidth);
                Teleport(pos);
                CleanUpAfterTeleport();
                return;
            }
            if (objectLeftX >= rightEdge)
            {
                pos.x = GetXToTeleportRight(objectLeftX, objectRightX, halfWidth);
                Teleport(pos);
                CleanUpAfterTeleport();
                return;
            }

            if (!IsTeleportingLeft(objectLeftX, objectRightX) && !IsTeleportingRight(objectLeftX, objectRightX))
            {
                // If we should no longer be teleporting
                CleanUpAfterTeleport();
                return;
            }
        }
    }

    float GetXToTeleportLeft(float leftEdgeX, float rightEdgeX, float halfWidth)
    {
        return rightEdge - halfWidth - (leftEdge - rightEdgeX);
    }

    float GetXToTeleportRight(float leftEdgeX, float rightEdgeX, float halfWidth)
    {
        return leftEdge + halfWidth + (leftEdgeX - rightEdge);
    }

    void Teleport(Vector3 position)
    {
        if (camera != null)
        {
            camera.GetComponent<CameraFollow>().Teleport(position);
        }
        transform.position = position;
    }

    void CleanUpAfterTeleport()
    {
        startedTeleporting = false;
        Destroy(clone);
    }

    bool IsTeleportingLeft(float leftEdgeX, float rightEdgeX)
    {
        return leftEdgeX < leftEdge && rightEdgeX > leftEdge;
    }

    bool IsTeleportingRight(float leftEdgeX, float rightEdgeX)
    {
        return leftEdgeX < rightEdge && rightEdgeX > rightEdge;
    }
}
