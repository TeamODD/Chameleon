using UnityEngine;
using UnityEngine.Rendering.Universal;

public class PlayerColorLogic : MonoBehaviour
{
    [SerializeField]
    ColorManager colorManager;

    public int playerColorIndex = 0;

    public GameObject interactionUI;
    private SpriteRenderer sr;

    private ColorChangeBlock currentChangeBlock;
    private bool canChangeColor = false;

    private ColorPortal currentPortal;
    private bool canRidePortal = false;

    private Vector2 movement = Vector2.zero;
    public float moveSpeed = 5f;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = colorManager.getSprite(playerColorIndex);
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
            playerColorIndex = currentChangeBlock.objectColorIndex;
            sr.sprite = colorManager.getSprite(currentChangeBlock.objectColorIndex);
        }

        // Ride the ColorPortal when interacting with it
        if (Input.GetKeyDown(KeyCode.F) && canRidePortal)
        {
            transform.position = currentPortal.linkedPortal.transform.position;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // 포탈
        if (other.CompareTag("ColorPortal"))
        {
            if (other.TryGetComponent(out ColorPortal portal))
            {
                // 색 매칭되는 포탈만 활성
                if (portal.objectColorIndex == playerColorIndex)
                {
                    currentPortal = portal;
                    canRidePortal = true;
                    interactionUI.SetActive(true);
                }
            }
        }

        // 컬러 체인지 블록
        if (other.CompareTag("ColorChangeBlock"))
        {
            if (other.TryGetComponent(out ColorChangeBlock block))
            {
                if (block.objectColorIndex == playerColorIndex)
                {
                    currentChangeBlock = block;
                    canChangeColor = true;
                    interactionUI.SetActive(true);
                }
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        // 포탈에서 벗어남
        if (other.CompareTag("ColorPortal"))
        {
            if (currentPortal != null && other.gameObject == currentPortal.gameObject)
            {
                currentPortal = null;
                canRidePortal = false;
                interactionUI.SetActive(false);
            }
        }

        // 컬러 블록에서 벗어남
        if (other.CompareTag("ColorChangeBlock"))
        {
            if (currentChangeBlock != null && other.gameObject == currentChangeBlock.gameObject)
            {
                currentChangeBlock = null;
                canChangeColor = false;
                interactionUI.SetActive(false);
            }
        }
    }
}