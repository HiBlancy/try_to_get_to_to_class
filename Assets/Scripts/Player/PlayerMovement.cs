using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement obj { get; private set; }

    [Header("Movement")]
    public float speed = 5f;
    public float jumpForce = 12f;
    private float moveHorizontal;
    public bool invertedControls = false;
    public bool autoJump = false;


    [Header("Ground Check")]
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float groundCheckDistance = 0.2f;
    [SerializeField] private float footWidth = 0.5f; // Ancho de los pies
    [SerializeField] private Transform groundCheckPoint;

    [Header("Wall Check")]
    [SerializeField] private float wallCheckHeight = 1f; // Altura del raycast vertical
    [SerializeField] private float wallCheckForwardOffset = 0.1f; // Pequeña distancia hacia adelante
    [SerializeField] private Transform wallCheckPoint; // Punto frontal a la altura del pecho
    private bool isGrounded;
    private bool isTouchingWall;

    [Header("Components")]
    private Rigidbody2D rb;
    private Animator animator;
    private bool canJump = true;

    private void Awake()
    {
        if (obj != null && obj != this)
            Destroy(gameObject);
        else
            obj = this;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        moveHorizontal = Input.GetAxisRaw("Horizontal");

        if (invertedControls)
        {
            moveHorizontal *= -1;
        }

        if (!(isTouchingWall && Mathf.Sign(moveHorizontal) == Mathf.Sign(transform.localScale.x)))
        {
            rb.velocity = new Vector2(moveHorizontal * speed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        isGrounded = CheckGrounded();
        isTouchingWall = CheckWalls();

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && canJump)
        {
            Jump();
        }
        else if (autoJump && isGrounded && canJump)
        {
            Jump();
        }


        animator.SetBool("isMoving", moveHorizontal != 0);
        animator.SetBool("isGrounded", isGrounded);

        if (moveHorizontal != 0)
        {
            transform.localScale = new Vector3(Mathf.Sign(moveHorizontal), 1, 1);
        }
    }

    private bool CheckGrounded()
    {
        Vector2 boxSize = new Vector2(footWidth * 0.9f, 0.1f);
        Vector2 boxCenter = groundCheckPoint.position;

        RaycastHit2D hit = Physics2D.BoxCast(
            boxCenter,
            boxSize,
            0f,
            Vector2.down,
            groundCheckDistance,
            groundLayer
        );

        // Debug visual mejorado
        Vector2 boxBottomCenter = boxCenter + Vector2.down * groundCheckDistance / 2;

        return hit.collider != null && !isTouchingWall;
    }

    private bool CheckWalls()
    {
        float raySpacing = wallCheckHeight / 3f;
        bool wallDetected = false;

        for (int i = 0; i < 3; i++)
        {
            Vector2 rayStart = new Vector2(
                wallCheckPoint.position.x + (Mathf.Sign(transform.localScale.x) * wallCheckForwardOffset),
                wallCheckPoint.position.y - wallCheckHeight / 2 + i * raySpacing
            );

            RaycastHit2D hit = Physics2D.Raycast(
                rayStart,
                Vector2.up,
                raySpacing,
                groundLayer
            );

            if (hit.collider != null)
            {
                wallDetected = true;
                break;
            }
        }

        return wallDetected;
    }

    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        canJump = false;
        Invoke(nameof(ResetJump), 0.2f);
    }

    private void ResetJump()
    {
        canJump = true;
    }
}