using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractionController : MonoBehaviour
{
    [SerializeField, Tooltip("Layers to check for interactions on")]
    private LayerMask _interactionLayers;

    private const float DetectionRadius = 1;

    public void CheckForInteractions()
    {
        Debug.Log("yee");
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, DetectionRadius, _interactionLayers);
        foreach (var hitCollider in hitColliders)
        {
            IInteractableObj interactableObj = hitCollider.GetComponent<IInteractableObj>();
            if (interactableObj != null)
            {
                // interactableObj.Interact();
            }
        }
    }
}
