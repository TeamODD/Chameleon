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
    public bool canChangeColor = false;

    private ColorPortal currentPortal;
    public bool canRidePortal = false;

    private ColorObstacle currentObstacle;
    public bool canInterObstacle = false;

    private ColorSwitch currentSwitch;
    //private bool canInterSwitch = false;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = colorManager.getSprite(playerColorIndex);
    }

    void Update()
    {
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

        // Interact with ColorObstacle
        if (Input.GetKeyDown(KeyCode.F) && canInterObstacle)
        {
            interactionUI.SetActive(false);
            // Red color
            if (playerColorIndex == 1)
            {
                currentObstacle.InteractionRed();
            }
            // Blue color
            else if(playerColorIndex == 2)
            {
                currentObstacle.InteractionBlue();
            }
            // Green color
            else if(playerColorIndex == 3)
            {
                currentObstacle.InteractionGreen();
            }
            // Yellow color
            else if(playerColorIndex == 4)
            {
                currentObstacle.InteractionYellow();
            }
        }

        /*
        // Interact with ColorSwitch
        if (canInterSwitch)
        {
            currentSwitch.SwitchOn();
        }
        */
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
                currentChangeBlock = block;
                canChangeColor = true;
                interactionUI.SetActive(true);
            }
        }

        // 색 장애물
        if (other.CompareTag("ColorObstacle"))
        {
            if (other.TryGetComponent(out ColorObstacle obstacle))
            {
                if (obstacle.objectColorIndex == playerColorIndex)
                {
                    currentObstacle = obstacle;
                    canInterObstacle = true;
                    interactionUI.SetActive(true);
                }
            }
        }

        // 색 스위치
        if (other.CompareTag("ColorSwitch"))
        {
            if (other.TryGetComponent(out ColorSwitch colorSwitch))
            {
                if (colorSwitch.objectColorIndex == playerColorIndex)
                {
                    currentSwitch = colorSwitch;
                    //canInterSwitch = true;
                    currentSwitch.SwitchOn();
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

        // 색 장애물에서 벗어남
        if (other.CompareTag("ColorObstacle"))
        {
            if (currentObstacle != null && other.gameObject == currentObstacle.gameObject)
            {
                currentObstacle = null;
                canInterObstacle = false;
                //interactionUI.SetActive(false);
            }
        }

        // 색 스위치에서 벗어남
        if (other.CompareTag("ColorSwitch"))
        {
            if(currentSwitch != null && other.gameObject == currentSwitch.gameObject)
            {
                currentSwitch = null;
                //canInterSwitch = false;
            }
        }
    }
}