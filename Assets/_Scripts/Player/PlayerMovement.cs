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

    [Header("Important Variables")]
    public bool _CanMove = true;
    public bool _InWater = false;

    [Header("Audio")]
    public AudioSource source;
    public AudioClip waterSound;
    public AudioClip waterJumpSound;

    [Header("FX")]
    public Color waterColor;
    public GameObject jumpDust;
    public GameObject jumpDustMove;

    [Header("References")]
    public SpriteRenderer sr;
    public GameObject bubbles;
    public Animator animator;
    public Transform groundPos;
    public FollowTarget[] hairParts;

    [Header("Private")]
    bool isJumping;
    bool canWaterJump = true;
    bool canMoveInWater = true;
    bool isGrounded;
    bool previousGroundedState;
    float waterMultiplier;
    Vector2 moveInput;
    Rigidbody2D rb;

    public hairDelegate updateHairGravity;
    public delegate void hairDelegate(float newGravity);

    float coyoteTimer;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        rb.gravityScale = defaultGravity;

        for (int i = 0; i < hairParts.Length; i++)
        {
            hairParts[i].InitHair(this);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!_CanMove) return;

        moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")); //Gets input and stores it

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

        if (_InWater)
        {
            WaterMovement();
        } else
        {
            NormalMovement();
        }
    }

    private void NormalMovement()
    {
        previousGroundedState = isGrounded;
        isGrounded = Physics2D.OverlapBox(groundPos.position, new Vector2(1f, .1f), 0f, groundMask); //Checks if player is grounded

        if (isGrounded)
        {
            coyoteTimer = coyoteTime;
            rb.gravityScale = defaultGravity;
        }
        else
        {
            coyoteTimer -= Time.deltaTime;
            rb.gravityScale = airGravity;
        }

        if (coyoteTimer > 0 || isGrounded)
        {
            animator.SetBool("CanJump", true);
        }
        else
        {
            animator.SetBool("CanJump", false);
        }

        if (Input.GetButtonDown("Jump") && coyoteTimer > 0)
        {
            Jump();

            isJumping = true;
            coyoteTimer = 0;
        }
        if (Input.GetButtonUp("Jump") && isJumping && rb.velocity.y > 0)
        {
            rb.AddForce(Vector2.down * rb.velocity.y * (1 - jumpCutMultipier), ForceMode2D.Impulse);
            isJumping = false;
            animator.ResetTrigger("Jump");
        }



        animator.SetFloat("Speed", rb.velocity.magnitude);
        animator.SetBool("IsGrounded", isGrounded);
        animator.SetBool("PreviousGrounded", previousGroundedState);

    }

    private void WaterMovement()
    {
        if (Input.GetButtonDown("Jump") && canWaterJump)
        {
            canMoveInWater = false;
            rb.gravityScale = 0f;
            rb.AddForce(moveInput * jumpForce, ForceMode2D.Impulse);
            source.PlayOneShot(waterJumpSound, .25f);

            bubbles.SetActive(true);
            canWaterJump = false;
            Invoke("ResetWaterJump", .5f);
            Invoke("ResetWaterMove", .5f);
        }
    }

    private void FixedUpdate()
    {
        if (!_CanMove) return;

        if(_InWater)//Sets the player velocity
        {
            if (!canMoveInWater) return;
            rb.velocity = new Vector2(moveInput.x * moveSpeed, moveInput.y * moveSpeed);
        } else
        {
            rb.velocity = new Vector2(moveInput.x * moveSpeed, rb.velocity.y);
        }
        
    }

    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);

        animator.SetTrigger("Jump");

        if(moveInput.x != 0)
        {
           GameObject obj = Instantiate(jumpDustMove, groundPos.position, Quaternion.identity);
           obj.transform.localScale = transform.localScale;
        } else
        {
            Instantiate(jumpDust, groundPos.position, Quaternion.identity);
        }
        
    }

    public void SetWater(bool inWater)
    {
        if(inWater)
        {
            _InWater = true;
            sr.color = waterColor;
            source.PlayOneShot(waterSound);
            animator.SetBool("IsGrounded", false);
            animator.SetBool("CanJump", false);
            updateHairGravity?.Invoke(0f);
        } else
        {
            _InWater = false;
            sr.color = Color.white;
            source.PlayOneShot(waterSound);
            updateHairGravity?.Invoke(.1f);
        }
    }

    public void ResetMovement()
    {
        _CanMove = false;
        rb.velocity = Vector2.zero;
        isGrounded = true;
        animator.SetFloat("Speed", 0f);
    }

    private void ResetWaterJump()
    {
        canWaterJump = true;
        bubbles.SetActive(false);
        rb.gravityScale = 1f;
    }
    private void ResetWaterMove()
    {
        canMoveInWater = true;
    }
}
