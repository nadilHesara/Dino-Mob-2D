using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;

    [Header("Movement Info")]
    public float jumpForce;
    public float moveSpeed;
    private bool runBegun;

    [Header("Collsion Info")]
    public float groundCheckDistance;
    public LayerMask whatIsGround;
    private bool isGrounded;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (runBegun)
            rb.linearVelocity = new Vector2(moveSpeed, rb.linearVelocity.y);


        CheckInput();
        CheckCollision();

    }

    private void CheckCollision()
    {
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, whatIsGround);
    }

    private void CheckInput()
    {
        if (Input.GetButtonDown("Fire2"))
            runBegun = true;

        if (Input.GetButtonDown("Jump") && isGrounded)
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, new Vector2(transform.position.x, transform.position.y - groundCheckDistance));
    }

}
