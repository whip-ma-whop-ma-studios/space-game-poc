using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerInteractionController : MonoBehaviour
{
    [SerializeField]
    private LayerMask _interactionLayers;

    [SerializeField]
    private InteractionPopupController _interactionPopupController;

    [SerializeField]
    private GameObject _player;

    private const float DetectionRadius = 1;

    private IEnumerable<Collider2D> _hitColliders;

    private void Update()
    {
        CheckForInteractions();
    }

    public void AttemptInteraction()
    {
        if (_hitColliders.Any())
        {
            foreach (var hitCollider in _hitColliders)
            {
                IInteractableObj interactableObj = hitCollider.GetComponent<IInteractableObj>();
                if (interactableObj != null)
                {
                    interactableObj.Interact(_player);
                }
            }
        }
    }

    public void CheckForInteractions()
    {
        _hitColliders = Physics2D.OverlapCircleAll(transform.position, DetectionRadius, _interactionLayers);
        if (_hitColliders.Any())
        {
            _interactionPopupController.Activate();
        }
        else
        {
            _interactionPopupController.Deactivate();
        }
    }
}
