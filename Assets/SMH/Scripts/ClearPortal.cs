using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClearPortal : MonoBehaviour
{
    [SerializeField]
    string nextScene;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("ClearPortal: OnTriggerEnter2D");
        SceneManager.LoadScene(nextScene);
    }
}
