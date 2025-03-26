using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    Rigidbody2D rb;

    public float jumpForce = 9f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            Jump();
    }

    public void Jump()
    {
        if (!PlayerMovment.obj.isGrounded) return;

        rb.velocity = Vector2.up * jumpForce;
        //AudioManager.obj.playJump();
    }
}
