using UnityEngine;

public class ColorObstacle : MonoBehaviour
{
    public int objectColorIndex;

    [SerializeField]
    GameObject tri;
    private Collider2D col;

    // blue
    [SerializeField]
    Sprite bluePlatformSprite;

    void Start()
    {
        // red
        if (objectColorIndex == 1)
        {
            col = tri.GetComponent<Collider2D>();
            col.isTrigger = false;
        }

        // green
        GameObject[] greenPlatform = GameObject.FindGameObjectsWithTag("GreenPlatform");
        foreach (GameObject platform in greenPlatform)
        {
            platform.GetComponent<SpriteRenderer>().enabled = false;
            platform.GetComponent<Collider2D>().enabled = false;
            platform.GetComponent<PlatformEffector2D>().enabled = false;
        }
    }

    public void InteractionRed()
    {
        /*
        col.isTrigger = true;
        tri.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
        */
        Destroy(gameObject);
    }

    public void InteractionBlue()
    {
        GameObject[] bluePlatform = GameObject.FindGameObjectsWithTag("BluePlatform");
        foreach (GameObject platform in bluePlatform)
        {
            platform.GetComponent<Collider2D>().isTrigger = false;
            platform.GetComponent<SpriteRenderer>().sprite = bluePlatformSprite;
            platform.gameObject.tag = "FrozenPlatform";
        }
    }

    public void InteractionGreen()
    {
        GameObject[] greenPlatform = GameObject.FindGameObjectsWithTag("GreenPlatform");
        foreach (GameObject platform in greenPlatform)
        {
            platform.GetComponent<SpriteRenderer>().enabled = true;
            platform.GetComponent<Collider2D>().enabled = true;
            platform.GetComponent<PlatformEffector2D>().enabled = true;
        }
    }

    public void InteractionYellow()
    {
        GameObject[] yellowPlatform = GameObject.FindGameObjectsWithTag("YellowPlatform");
        foreach (GameObject platform in yellowPlatform)
        {
            platform.transform.Rotate(0, 0, 90f);
        }
    }
}