using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 7f;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public LayerMask wallLayer;
    public float groundCheckRadius = 0.4f;
    public float wallCheckDistance = 0.5f;
    public float wallSlideSpeed = 1f; // Speed at which player slides down the wall

    private Animator animator;
    private Rigidbody rb;
    private bool isGrounded;
    private bool isTouchingWall;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Move();
        Flip();

        if (Input.GetButtonDown("Jump") && isGrounded && !isTouchingWall)
        {
            Jump();
        }
    }

    void FixedUpdate()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundCheckRadius, groundLayer);
        CheckForWall();
    }

    private void Move()
    {
        float move = Input.GetAxis("Horizontal");

        if (isTouchingWall)
        {
            move = 0; // Stop horizontal movement when touching a wall
            WallSlideControl(); // Control wall sliding
        }

        rb.velocity = new Vector3(move * moveSpeed, rb.velocity.y, 0);
    }

    private void Flip()
    {
        if (rb.velocity.x > 0.1)
        {
            animator.SetBool("IsMoving", true);
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (rb.velocity.x < -0.1)
        {
            animator.SetBool("IsMoving", true);
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            animator.SetBool("IsMoving", false);
        }
    }


    private void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    private void CheckForWall()
    {
        isTouchingWall = Physics.Raycast(transform.position, Vector3.right, wallCheckDistance, wallLayer)
                       || Physics.Raycast(transform.position, Vector3.left, wallCheckDistance, wallLayer);
    }

    private void WallSlideControl()
    {
        if (rb.velocity.y < -wallSlideSpeed)
        {
            rb.velocity = new Vector3(rb.velocity.x, -wallSlideSpeed, 0); // Control slide speed
        }
    }

    //void OnDrawGizmosSelected()
    //{
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawLine(transform.position, transform.position + Vector3.right * wallCheckDistance);
    //    Gizmos.DrawLine(transform.position, transform.position + Vector3.left * wallCheckDistance);
    //}
}
