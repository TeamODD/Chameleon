using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToMainMenu : MonoBehaviour
{
    [SerializeField] private GameObject MainMenu;
    [SerializeField] private GameObject currentScean;
    
  

    // Update is called once per frame

    public void GoToMainScene()
    {

        currentScean.SetActive(false);
        MainMenu.SetActive(true);
    }
}
