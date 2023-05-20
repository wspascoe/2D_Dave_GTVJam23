using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float moveSpeed;
    [SerializeField] float jumpForce;
    [SerializeField] Transform groundPoint;
    [SerializeField] Animator anim;
    [SerializeField] Animator flipAnim;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] LayerMask groundLayer;

    private bool isGrounded;
    private bool moveBackwards;
    private Vector2 moveInput;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Move();
        Jump();
        UpdateAnimator();
    }

    private void UpdateAnimator()
    {
        anim.SetBool("onGround", isGrounded);

        if (!spriteRenderer.flipX && moveInput.x < 0)
        {
            spriteRenderer.flipX = true;
            flipAnim.SetTrigger("Flip");
        }
        else if (spriteRenderer.flipX && moveInput.x > 0)
        {
            spriteRenderer.flipX = false;
            flipAnim.SetTrigger("Flip");
        }

        if (!moveBackwards && moveInput.y > 0)
        {
            moveBackwards = true;
            flipAnim.SetTrigger("Flip");
        }
        else if (moveBackwards && moveInput.y < 0)
        {
            moveBackwards = false;
            flipAnim.SetTrigger("Flip");
        }

        anim.SetBool("movingBackwards", moveBackwards);
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity += new Vector3(0f, jumpForce, 0f);
        }
    }

    private void Move()
    {
        moveInput.x = Input.GetAxis("Horizontal");
        moveInput.y = Input.GetAxis("Vertical");
        moveInput.Normalize();

        rb.velocity = new Vector3(moveInput.x * moveSpeed, rb.velocity.y, moveInput.y * moveSpeed);

        anim.SetFloat("moveSpeed", rb.velocity.magnitude);

        RaycastHit hit;
        if (Physics.Raycast(groundPoint.position, Vector3.down, out hit, 0.3f, groundLayer))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }
}
