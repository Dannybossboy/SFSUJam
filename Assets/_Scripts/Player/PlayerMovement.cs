using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Variables")]
    public float moveSpeed = 5f;
    public float jumpForce = 10f;

    public LayerMask groundMask;

    [Header("Important Variables")]
    public bool _CanMove = true;

    [Header("References")]
    public Transform groundPos;

    [Header("Private")]
    
    bool isGrounded;
    Vector2 moveInput;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_CanMove) return;

        isGrounded = Physics2D.OverlapCircle(groundPos.position, .5f, groundMask); //Checks if player is grounded

        moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")); //Gets input and stores it

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            Jump();
        }
    }

    private void FixedUpdate()
    {
        if (!_CanMove) return;
        rb.velocity = new Vector2(moveInput.x * moveSpeed, rb.velocity.y); //Sets the player velocity
    }

    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }
}
