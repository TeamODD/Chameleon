using UnityEngine;

public class QuitGame : MonoBehaviour
{
    public void quitGame()
    {
        Debug.Log("게임 종료");
        Application.Quit();
    }
 
}
