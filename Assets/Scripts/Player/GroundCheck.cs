using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [SerializeField]
    private PlayerMovementController _playerMovementController;
    [SerializeField]
    private float boxHeight = 0.05f;
    [SerializeField]
    private float boxWidthMultiplier = 0.9f;
    [SerializeField]
    private LayerMask groundLayer;

    private Vector2 playerSize;
    private Vector2 boxSize;

    void Start()
    {
        playerSize = GetComponent<BoxCollider2D>().size;
        boxSize = new Vector2(playerSize.x * boxWidthMultiplier, boxHeight);
    }

    void OnDrawGizmos()
    {
        Vector2 boxCenter = (Vector2)transform.position + Vector2.down * (playerSize.y + boxHeight) / 2;
        var left = boxCenter.x - boxSize.x / 2;
        var right = boxCenter.x + boxSize.x / 2;
        var top = boxCenter.y + boxSize.y / 2;
        var bottom = boxCenter.y - boxSize.y / 2;
        Gizmos.DrawLine(new Vector3(left, top), new Vector3(left, bottom));
        Gizmos.DrawLine(new Vector3(left, bottom), new Vector3(right, bottom));
        Gizmos.DrawLine(new Vector3(right, bottom), new Vector3(right, top));
        Gizmos.DrawLine(new Vector3(right, top), new Vector3(left, top));
    }

    void Update()
    {
        Vector2 boxCenter = (Vector2)transform.position + Vector2.down * (playerSize.y + boxHeight) / 2;
        _playerMovementController.grounded = Physics2D.OverlapBox(boxCenter, boxSize, 0, groundLayer) != null;
    }
}
