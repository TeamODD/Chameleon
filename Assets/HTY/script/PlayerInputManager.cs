using UnityEngine;

public class PlayerInputManager : MonoBehaviour
{
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = -Physics2D.gravity.y; // MORE smooth gravity
    }

    [SerializeField] private float Speed = 10f; 
    [SerializeField] private float Height = 10f;
    [SerializeField] private bool _isOnGround = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("obstacle"))
        {
            _isOnGround = false;
            foreach (ContactPoint2D contact in collision.contacts) // I DONT KNOW 
            {

                if (contact.normal.y > 0.5f)
                {
                    _isOnGround = false;
                    Debug.Log("Enter_Collision : Ground Detected");
                    break;
                }
            }
        }
        else
        {
            _isOnGround = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("platform"))
        {
            Debug.Log("Exit_Collision");
            if (_isOnGround == false)
            {
                _isOnGround = true;
            }
        }
    }

    public void movePlayer()
    {
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
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * Speed * Time.deltaTime);
            Debug.Log("Key 'D' has been downed");
        }
    }


    private void Jump()
    {
        float initialVelocity = CalculateInitialVelocity(Height); // float Height = 10f;
        rb.linearVelocityY = 0;
        rb.AddForce(Vector2.up * initialVelocity, ForceMode2D.Impulse);
        _isOnGround = false;
    }

    private float CalculateInitialVelocity(float height)
    {
        // Physics2D.gravity.y = 9.8f 
        float gravityVelocity = Physics2D.gravity.y * Physics2D.gravity.y;
        return Mathf.Sqrt(2f * gravityVelocity * height);
    }
    
}
