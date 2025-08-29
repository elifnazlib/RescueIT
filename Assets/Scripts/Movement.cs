using UnityEngine;
using UnityEngine.SceneManagement;
public class Movement : MonoBehaviour
{
    public float horizontal;
    [SerializeField] private float speed = 4f;
    [SerializeField] private float jumpingPower = 8f;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float groundCheckRadius = 0.2f;

    [SerializeField] CountdownController _countdownController;
    [SerializeField] float leftValueX;
    [SerializeField] float rightValueX;

    private bool canMoveLeftAndRight = true;
    private bool canJump = true;

    [SerializeField] Animator animator;

    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Level1")
        {
            Debug.Log("Level name: " + SceneManager.GetActiveScene().name);
            canJump = true;
            canMoveLeftAndRight = false;
        }
        else if (SceneManager.GetActiveScene().name == "Level2")
        {
            Debug.Log("Level name: " + SceneManager.GetActiveScene().name);
            canMoveLeftAndRight = true;
            canJump = false;
        }
        else if (SceneManager.GetActiveScene().name == "Level3")
        {
            Debug.Log("Level name: " + SceneManager.GetActiveScene().name);
            canMoveLeftAndRight = true;
            canJump = false;
        }
    }

    void Update()
    {
        Vector2 move = transform.position;
        move.x = Mathf.Clamp(move.x, leftValueX, rightValueX);
        transform.position = move;


        if (_countdownController.isGameStarted)
        {
            horizontal = Input.GetAxisRaw("Horizontal");

            if (canJump == true)
            {
                if (Input.GetButtonDown("Jump") && IsGrounded())
                {
                    rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
                }

                if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
                {
                    rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
                }
            }
        }

        if (IsGrounded())
        {
            animator.SetBool("isJumping", false);
        }
        else
        {
            animator.SetBool("isJumping", true);
        }
    }

    void FixedUpdate()
    {
        if (canMoveLeftAndRight == true)
        {
            if (_countdownController.isGameStarted)
                rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}