using System.Collections;
using UnityEngine;

public class PlayerInputController : MonoBehaviour
{
    [SerializeField]
    private PlayerMovementController _playerMovementController;
    [SerializeField]
    private LayerMask groundLayer;
    public static bool PlayerInputEnabled = true;

    private PlayerInteractionController _playerInteractionController;

    void Awake()
    {
        _playerInteractionController = gameObject.GetComponent<PlayerInteractionController>();
    }

    void Update()
    {
        if (PlayerInputEnabled)
        {
            HorizontalMovementCheck();
            JumpCheck();
            InteractionCheck();
        }
    
    }

    private void HorizontalMovementCheck()
    {
        if (Input.GetKey(KeyCode.A))
        {
            _playerMovementController.MoveHorizontal(false);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            _playerMovementController.MoveHorizontal(true);
        }
        else
        {
            _playerMovementController.StopHorizontalMovement();
        }
    }

    private void JumpCheck()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _playerMovementController.AttemptJump();
            StartCoroutine("SmallJumpCheck");
        }
    }

    private IEnumerator SmallJumpCheck()
    {
        var waitTime = 0.1f;
        var endTime = 0.2f;

        for (float time = 0f; time <= endTime; time += waitTime)
        {
            if (!Input.GetKey(KeyCode.Space))
            {
                _playerMovementController.SmallJump();
                yield break;
            }
            yield return new WaitForSeconds(waitTime);
        }
    }

    public void InteractionCheck()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            _playerInteractionController.AttemptInteraction();
        }
    }

}
