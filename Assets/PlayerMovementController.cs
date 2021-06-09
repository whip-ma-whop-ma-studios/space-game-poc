using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    private Rigidbody2D _rb;

    [SerializeField]
    private float _jumpForce = 350f;
    [SerializeField]
    private float _fallMultiplier = 1.5f;
    [SerializeField]
    private float _lowJumpMultiplier = 3f;
    [SerializeField]
    private float _horizontalSpeed = 5f;

    private bool _grounded;
    public bool grounded
    {
        get => _grounded;
        set
        {
            _grounded = value;
            if (value)
            {
                _doubleJump = false;
                _rb.gravityScale = 1;
            }
        }
    }

    private bool _doubleJump;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        FallFaster();
    }

    public void MoveHorizontal(bool moveRight)
    {
        if (moveRight)
        {
            _rb.velocity = new Vector2(_horizontalSpeed, _rb.velocity.y);
        }
        else
        {
            _rb.velocity = new Vector2(-_horizontalSpeed, _rb.velocity.y);
        }
    }

    public void StopHorizontalMovement()
    {
        _rb.velocity = new Vector2(0, _rb.velocity.y);
    }

    private void FallFaster()
    {
        if (_rb.velocity.y < 0)
        {
            _rb.gravityScale = _fallMultiplier;
        }
    }

    public void AttemptJump()
    {
        if (_grounded || !_doubleJump)
        {
            Jump();
        }
    }

    public void SmallJump()
    {
        _rb.gravityScale = _lowJumpMultiplier;
    }

    private void Jump()
    {
        if (!_doubleJump && !_grounded)
        {
            _doubleJump = true;
        }

        _rb.gravityScale = 1;
        _rb.velocity = new Vector2(_rb.velocity.x, 0);
        _rb.AddForce(Vector2.up * _jumpForce);
    }
}
