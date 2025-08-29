using System.Collections;
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
    private bool canAttack = false;

    [SerializeField] Animator animator;
    [SerializeField] Boss _bossScript;
    public bool playerAttack = false;

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
            canAttack = true;
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

            if (horizontal == 0) animator.SetBool("isRunning", false);
            else animator.SetBool("isRunning", true);

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

        if (canAttack == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                playerAttack = true;
                animator.SetBool("isPunching", true);
                StartCoroutine(WaitHalfSeconds());
            }
        }
    }

    void FixedUpdate()
    {
        if (canMoveLeftAndRight == true)
        {
            if (_countdownController.isGameStarted)
            {
                rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
            }
                
        }
    }

    IEnumerator WaitHalfSeconds()
    {
        yield return new WaitForSeconds(0.5f);
        playerAttack = false;
        animator.SetBool("isPunching", false);
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