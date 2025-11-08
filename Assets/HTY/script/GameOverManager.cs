using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "GameOverBox")
        {
            Debug.Log("Game Over");
            string currentScene = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentScene);
            new WaitForSeconds(1f);
        }
        else
        {
            Debug.Log("GameOverBox Error: Something is wrong!");
        }
    }
}
