using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementRb : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    [SerializeField] Vector2 jumpForce;
    [SerializeField] int jumpMaxNumber = 2;

    Rigidbody2D rb;

    int jumpNumber = 0;
    float moveX;
    bool isJumping = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        GetUserInput();
    }

    private void FixedUpdate()
    {
        Move();
        Jump();
    }

    void GetUserInput()
    {

        moveX = Input.GetAxisRaw("Horizontal");
        if (Input.GetButtonDown("Jump"))
        {
            isJumping = true;
        }
    }

    void Move()
    {
        rb.velocity = new(moveX * speed, rb.velocity.y);
    }

    void Jump()
    {
        if(isJumping && jumpNumber < jumpMaxNumber)
        {
            rb.AddForce(jumpForce, ForceMode2D.Impulse);
            jumpNumber++;
            isJumping=false;
        }

        if(Mathf.Abs(rb.velocity.y) < 0.001f)
        {
            jumpNumber = 0;
            isJumping = false;
        }

    }
}
