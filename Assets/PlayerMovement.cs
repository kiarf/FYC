
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask collisionLayers;
    public Rigidbody2D rb;
    private Vector3 velocity = Vector3.zero;
    private bool isGrounded;
    private bool isJumping;

    public float jumpForce;

    private float horizontalMovement;


    void Update() {
        
        if(Input.GetButtonDown("Jump") && isGrounded) {
            isJumping = true;
        }

         horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed;
    }

    void FixedUpdate() {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, collisionLayers);
        MovePlayer(horizontalMovement);
    }

    void MovePlayer(float _horizontalMovement) {

        rb.velocity = new Vector2(_horizontalMovement, rb.velocity.y);

        if (isJumping == true) {
            rb.AddForce(new Vector2(0f, jumpForce));
            isJumping = false;
        }
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}

