using UnityEngine;

public class PlayerInputManager : MonoBehaviour
{
    private Rigidbody2D rb;

    void Start()
    {
        spriterender = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        capsuleCollider2D = rb.GetComponent<CapsuleCollider2D>();
        rb.gravityScale = -Physics2D.gravity.y; // MORE smooth gravity
    }

    [SerializeField] private float Speed = 10f; 
    [SerializeField] private float Height = 10f;
    [SerializeField] private bool _isOnGround = false;
    [SerializeField] private LayerMask collisionLayer;
    private SpriteRenderer spriterender;
    
    private Vector3 footPosition;
    private CapsuleCollider2D capsuleCollider2D;

    public void movePlayer()
    {
        Bounds bounds = capsuleCollider2D.bounds;
        footPosition = new Vector2(bounds.center.x, bounds.min.y);
        _isOnGround = Physics2D.OverlapCircle(footPosition, 0.1f, collisionLayer);

        _movePlayer();


        if (Input.GetKey(KeyCode.Space))
        {

            Debug.Log("Key 'Space' has been downed");

            if (_isOnGround == true)
            {
                // jump() function is not mine.
                // So, I DONT KNOW HOW IT WORKS. :> LOL
                // No. I Can EXPLAIN now, HOW IT WORKS. :)
                Jump();

            }
            else
            {
                Debug.Log("Player is Not OnGround");
            }

        }
    }
    private void _movePlayer()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * Speed * Time.deltaTime);
            Debug.Log("Key 'A' has been downed");
            spriterender.flipX = true;

        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * Speed * Time.deltaTime);
            Debug.Log("Key 'D' has been downed");
            spriterender.flipX = false;
        }
    }


    private void Jump()
    {
        float initialVelocity = CalculateInitialVelocity(Height); // float Height = 10f;
        rb.linearVelocityY = 0;
        rb.AddForce(Vector2.up * initialVelocity, ForceMode2D.Impulse);
        
        _isOnGround = false;
        Debug.Log("jump1");

    }

    private float CalculateInitialVelocity(float height)
    {
        // Physics2D.gravity.y = 9.8f 
        float gravityVelocity = Physics2D.gravity.y * Physics2D.gravity.y;
        return Mathf.Sqrt(2f * gravityVelocity * height);
    }
    
}
