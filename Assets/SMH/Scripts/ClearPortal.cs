using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClearPortal : MonoBehaviour
{
    [SerializeField]
    string nextScene;
    PlayerColorLogic pcl;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pcl = GetComponent<PlayerColorLogic>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (pcl.playerColorIndex != 0)
                return;
        Debug.Log("ClearPortal: OnTriggerEnter2D");
        SceneManager.LoadScene(nextScene);
        }
    }
}
