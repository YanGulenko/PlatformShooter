using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PlayerAnimator))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _jumpForce;
    [SerializeField] private bool _isGrounded;
    [SerializeField] private LayerMask _groundMask;
    [SerializeField] private float _jumpOffset;
    [SerializeField] private float _speed;
    private Rigidbody2D _playerRigidBody;
    private PlayerAnimator _playerAnimator;
    public bool PlayerRightRotation;

    private void Awake()
    {
        PlayerRightRotation = true;
        _playerRigidBody = GetComponent<Rigidbody2D>();
        _playerAnimator = GetComponent<PlayerAnimator>();    
    }

    private void FixedUpdate()
    { 
        _isGrounded = Physics2D.OverlapCircle(transform.position, _jumpOffset, _groundMask);
        _playerAnimator.IsGrounded(_isGrounded);
        _playerAnimator.SpeedCheck(_playerRigidBody.velocity.y);
    }

    public void Move(float direction, bool isJumpPressed)
    {
        if (direction != 0) 
        { 
            if (direction <0)
            {
                transform.localScale = new Vector3( -3 , 3 , 3);
                PlayerRightRotation = false;
            }
            else
            {
                transform.localScale = new Vector3(3, 3, 3);
                PlayerRightRotation = true;
            }
            _playerRigidBody.velocity = new Vector2(_speed * direction, _playerRigidBody.velocity.y);
            _playerAnimator.Run();
        }
        else
        {
            _playerAnimator.StopRun();
        }
        if (isJumpPressed) { Jump(); }
    }

    private void Jump()
    {
        if (_isGrounded)
        {
            _playerRigidBody.velocity = new Vector2(_playerRigidBody.velocity.x, _jumpForce);
        }
    }
}