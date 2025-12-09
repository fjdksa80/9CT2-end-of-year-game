using UnityEngine;
using System.Collections.Generic;

public class Movement : MonoBehaviour
{
    private float velocityX;
    private float velocityY;
    public float speed = 8f;
    public float jumpSpeed = 16f;
    private float horizontal;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        velocityX += horizontal*speed;
        velocityX *= 0.9f;
        velocityY += -0.1f;
        if(isGrounded())
        {
            velocityY = 0f;
        }
        if(Input.GetButtonDown("Jump") && isGrounded())
        {
            transform.position = new Vector2(transform.position.x, transform.position.y+0.01f);
            velocityY = jumpSpeed;
        }
        Debug.Log(isGrounded());
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(velocityX,velocityY);
    }

    private bool isGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.01f, groundLayer);
    }
}
