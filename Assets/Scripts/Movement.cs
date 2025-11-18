using UnityEngine;

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
        velocityY += -1;
        if(isGrounded())
        {
            velocityY = 0;
        }

        if (Input.GetButtonDown("Jump"))
        {
            velocityY = jumpSpeed;
        }
        Debug.Log(velocityY);
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(velocityX,velocityY);
    }

    private bool isGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
}
