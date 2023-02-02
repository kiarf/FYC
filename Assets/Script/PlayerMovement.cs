using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Animator animator;
    public LayerMask collisionLayers;

    public Transform groundCheck;
    public float groundCheckRadius;

    private float horizontalMovement;
    private bool isGrounded;
    private bool isJumping;

    public float jumpForce;
    public float moveSpeed;
    public Rigidbody2D rb;

    public SpriteRenderer spriteRenderer;
    private Vector3 velocity = Vector3.zero;

    private void Update()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isJumping = true;
        }

        horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed;

        var characterVelocity = Mathf.Abs(rb.velocity.x);
        animator.SetFloat("Speed", characterVelocity);
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, collisionLayers);
        Flip(rb.velocity.x);
        MovePlayer(horizontalMovement);
    }

    private void MovePlayer(float _horizontalMovement)
    {
        rb.velocity = new Vector2(_horizontalMovement, rb.velocity.y);

        if (isJumping)
        {
            rb.AddForce(new Vector2(0f, jumpForce));
            isJumping = false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }

    private void Flip(float _velocity)
    {
        if (_velocity > 0.1f)
        {
            spriteRenderer.flipX = false;
        }
        else if (_velocity < -0.1f)
        {
            spriteRenderer.flipX = true;
        }
    }
}