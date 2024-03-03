using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Variables")]
    public float moveSpeed = 5f;
    public float jumpForce = 10f;

    public float jumpCutMultipier = 2f;
    public float coyoteTime = .2f;

    public float defaultGravity = 2f;
    public float airGravity = 3f;

    public LayerMask groundMask;

    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip[] footsteps;

    [Header("Important Variables")]
    public bool _CanMove = true;

    [Header("References")]
    public Transform groundPos;

    [Header("Private")]
    bool isJumping;
    bool isGrounded;
    Vector2 moveInput;
    Rigidbody2D rb;
    Animator animator;

    float coyoteTimer;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        rb.gravityScale = defaultGravity;
    }

    // Update is called once per frame
    void Update()
    {
        if (!_CanMove) return;

        isGrounded = Physics2D.OverlapBox(groundPos.position, new Vector2(1f,.1f), 0f, groundMask); //Checks if player is grounded

        if(isGrounded)
        {
            coyoteTimer = coyoteTime;
            rb.gravityScale = defaultGravity;
        } else
        {
            coyoteTimer -= Time.deltaTime;
            rb.gravityScale = airGravity;
        }

        moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")); //Gets input and stores it

        if(Input.GetButtonDown("Jump") && coyoteTimer > 0)
        {
            Jump();

            isJumping = true;
            coyoteTimer = 0;
        }
        if(Input.GetButtonUp("Jump") && isJumping && rb.velocity.y > 0)
        {
            rb.AddForce(Vector2.down * rb.velocity.y * (1 - jumpCutMultipier), ForceMode2D.Impulse);
            isJumping = false;
        }

        #region Flip Player
        if (moveInput.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (moveInput.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        #endregion

        animator.SetFloat("Speed", rb.velocity.magnitude);
        animator.SetBool("IsGrounded", isGrounded);

    }

    private void FixedUpdate()
    {
        if (!_CanMove) return;
        rb.velocity = new Vector2(moveInput.x * moveSpeed, rb.velocity.y); //Sets the player velocity
    }

    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        animator.SetTrigger("Jump");
    }

    public void PlayFootstepSound()
    {
        audioSource.PlayOneShot(footsteps[Random.Range(0, footsteps.Length)]);
    }
}
