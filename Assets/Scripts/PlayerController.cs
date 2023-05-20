using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float jumpForce;
    [SerializeField] Transform groundPoint;
    [SerializeField] Animator anim;
    [SerializeField] Animator flipAnim;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] LayerMask groundLayer;

    private Rigidbody rb;
    private InputReader inputReader;
    private bool isGrounded;
    private bool moveBackwards;
    private Vector2 moveInput;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        inputReader = GetComponent<InputReader>();
    }

    private void Start()
    {
        inputReader.JumpEvent += Jump;
    }

    private void OnDisable()
    {
        inputReader.JumpEvent -= Jump;
    }

    private void Update()
    {
        Move();
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
        if (isGrounded)
        {
            rb.velocity += new Vector3(0f, jumpForce, 0f);
        }
    }

    private void Move()
    {
        moveInput = inputReader.MovementValue;
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
