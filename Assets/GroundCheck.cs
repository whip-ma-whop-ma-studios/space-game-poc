using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [SerializeField]
    private PlayerMovementController _playerMovementController;
    [SerializeField]
    private float boxHeight = 0.05f;
    [SerializeField]
    private LayerMask groundLayer;

    private Vector2 playerSize;
    private Vector2 boxSize;

    void Start()
    {
        playerSize = GetComponent<BoxCollider2D>().size;
        boxSize = new Vector2(playerSize.x, boxHeight);
    }

    void Update()
    {
        Vector2 boxCenter = (Vector2)transform.position + Vector2.down * (playerSize.y + boxHeight) / 2;
        _playerMovementController.grounded = Physics2D.OverlapBox(boxCenter, boxSize, 0, groundLayer) != null;
    }
}
