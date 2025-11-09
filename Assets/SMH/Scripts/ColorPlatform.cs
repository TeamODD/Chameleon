using UnityEngine;

public class ColorPlatform : MonoBehaviour
{
    public int objectColorIndex;
    GameObject player;
    PlayerColorLogic pcl;
    Collider2D col;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        pcl = player.GetComponent<PlayerColorLogic>();
        col = gameObject.GetComponent<Collider2D>();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (gameObject.CompareTag("BluePlatform"))
        {
            gameObject.layer = LayerMask.NameToLayer("Default");
            col.isTrigger = true;
        }
        else if (collision.gameObject.CompareTag("Player"))
        {
            if (pcl.playerColorIndex != objectColorIndex)
            {
                gameObject.layer = LayerMask.NameToLayer("Default");
                col.isTrigger = true;
            }
            else
            {
                gameObject.layer = LayerMask.NameToLayer("platform");
                col.isTrigger = false;
            }
        }
    }
}