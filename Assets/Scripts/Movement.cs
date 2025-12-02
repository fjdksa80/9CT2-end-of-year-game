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


        
        Debug.Log(velocityY);
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(velocityX,velocityY);
    }

    void OnCollisionEnter2D(Collision2D collision) //Function to enable jumping again after landing.
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            if (Input.GetButtonDown("Jump"))
            {
            velocityY = jumpSpeed;
            }

        }
    }
}
