using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    public static PlayerMovment obj { get; private set; }

    bool isMoving = false;
    public bool isGrounded = false;

    public float speed = 5f;
    float moveHorizontal;

    [SerializeField] LayerMask groundLayer;
    float radius = 0.3f;
    float groundRayDist = 0.5f;

    Rigidbody2D rb;
    Animator animator;
    SpriteRenderer spriteRenderer;

    void Awake()
    {
        if (obj != null && obj != this)
            Destroy(this);
        else
            obj = this;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        moveHorizontal = Input.GetAxisRaw("Horizontal");

        isMoving = (moveHorizontal != 0);

        isGrounded = Physics2D.CircleCast(transform.position, radius, Vector3.down, groundRayDist, groundLayer);

        animator.SetBool("isMoving", isMoving);
        animator.SetBool("isGrounded", false);

        Flip(moveHorizontal);
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(moveHorizontal * speed, rb.velocity.y);
    }

    void Flip(float xVlaue)
    {
        Vector3 theScale = transform.localScale;

        if (xVlaue < 0)
            theScale.x = Mathf.Abs(theScale.x) * -1;
        else
        if (xVlaue > 0)
            theScale.x = Mathf.Abs(theScale.x);

        transform.localScale = theScale;
    }
}
