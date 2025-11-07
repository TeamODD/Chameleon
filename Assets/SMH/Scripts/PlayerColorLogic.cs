using UnityEngine;
using UnityEngine.Rendering.Universal;

public class PlayerColorLogic : MonoBehaviour
{
    [SerializeField]
    ColorManager colorManager;

    public string playerColor;
    public int playerColorIndex = 0;

    public GameObject interactionUI;
    private SpriteRenderer sr;

    private ColorChangeBlock colorChangeBlock;
    private bool canChangeColor = false;

    private ColorPortal colorPortal;
    private bool canRidePortal = false;

    private Vector2 movement = Vector2.zero;
    public float moveSpeed = 5f;

    private void Awake()
    {
        playerColor = colorManager.getColor(playerColorIndex);
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.A))
            movement += Vector2.left;
        if(Input.GetKey(KeyCode.D))
            movement += Vector2.right;
        transform.Translate(moveSpeed * movement * Time.deltaTime, Space.World);
        movement = Vector2.zero;

        // Change color when interacting with a ColorChangeBlock
        if (Input.GetKeyDown(KeyCode.F) && canChangeColor)
        {
            playerColorIndex = colorChangeBlock.objectColorIndex;
            playerColor = colorManager.getColor(playerColorIndex);
            sr.sprite = colorManager.getSprite(colorChangeBlock.objectColorIndex);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        // Show interaction UI when near a ColorChangeBlock
        if (collision.gameObject.CompareTag("ColorChangeBlock"))
        {
            interactionUI.SetActive(true);
            colorChangeBlock = collision.gameObject.GetComponent<ColorChangeBlock>();
            canChangeColor = true;
        }


        if (collision.gameObject.CompareTag("ColorPortal"))
        {
            ColorPortal colorPortal = collision.gameObject.GetComponent<ColorPortal>();
            if (colorPortal.objectColorIndex == playerColorIndex)
            {
                canRidePortal = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // Hide interaction UI when leaving a ColorChangeBlock
        if (collision.gameObject.CompareTag("ColorChangeBlock"))
        {
            interactionUI.SetActive(false);
            canChangeColor = false;
        }
    }
}