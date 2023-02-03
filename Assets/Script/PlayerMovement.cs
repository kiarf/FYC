using UnityEngine;

namespace Assets.Script
{
    public class PlayerMovement : MonoBehaviour
    {
        public static PlayerMovement instance;

        private float _horizontalMovement;
        private bool _isGrounded;
        private bool _isJumping;
        private float _verticalMovement;
        public Animator animator;
        public LayerMask collisionLayers;

        public Transform groundCheck;
        public float groundCheckRadius;
        public bool isClimbing;

        public float jumpForce;
        public float moveSpeed;
        public CapsuleCollider2D playerCollider;
        public Rigidbody2D rb;

        public SpriteRenderer spriteRenderer;

        private void Awake()
        {
            if (instance != null)
            {
                Debug.LogWarning("Numerous PlayerMovement instances in the scene");
                return;
            }

            instance = this;
        }

        private void Update()
        {
            if (Input.GetButtonDown("Jump") && _isGrounded)
            {
                _isJumping = true;
            }

            _horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed;
            _verticalMovement = Input.GetAxis("Vertical") * moveSpeed;

            var characterVelocity = Mathf.Abs(rb.velocity.x);
            animator.SetFloat("Speed", characterVelocity);
        }

        private void FixedUpdate()
        {
            _isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, collisionLayers);
            Flip(rb.velocity.x);
            MovePlayer(_horizontalMovement, _verticalMovement);
        }

        private void MovePlayer(float horizontalMovement, float verticalMovement)
        {
            rb.velocity = new Vector2(horizontalMovement, rb.velocity.y);

            if (_isJumping)
            {
                rb.AddForce(new Vector2(0f, jumpForce));
                _isJumping = false;
            }

            if (isClimbing)
            {
                rb.velocity = new Vector2(rb.velocity.x, verticalMovement);
                _isJumping = false;
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        }

        private void Flip(float velocity)
        {
            if (velocity > 0.1f)
            {
                spriteRenderer.flipX = false;
            }
            else if (velocity < -0.1f)
            {
                spriteRenderer.flipX = true;
            }
        }
    }
}