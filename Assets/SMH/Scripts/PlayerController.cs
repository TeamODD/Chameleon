using UnityEngine;
using UnityEngine.Rendering.Universal;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    ScriptManager scriptManager;

    public string playerColor;
    public int playerColorIndex = 0;

    private Vector2 movement = Vector2.zero;
    public float moveSpeed = 5f;

    private void Awake()
    {
        playerColor = scriptManager.getColor(playerColorIndex);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.A))
            movement += Vector2.left;
        if(Input.GetKey(KeyCode.D))
            movement += Vector2.right;
        transform.Translate(moveSpeed * movement * Time.deltaTime, Space.World);
        movement = Vector2.zero;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ColorChangeBlock"))
        {
            ColorChangeBlock colorChangeBlock = collision.gameObject.GetComponent<ColorChangeBlock>();
            playerColorIndex = colorChangeBlock.objectColorIndex;
            playerColor = scriptManager.getColor(playerColorIndex);
            gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            if (scriptManager.isSameColor(playerColorIndex, colorChangeBlock.objectColorIndex))
            {
                Debug.Log("Same");
            }
            else
            {
                Debug.Log("Not Same");
            }
        }
    }
}
