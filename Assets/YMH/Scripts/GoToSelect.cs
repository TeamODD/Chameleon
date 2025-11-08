using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToSelect : MonoBehaviour
{
    [SerializeField]private GameObject stageSelect;
    [SerializeField] private GameObject MainMenu;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        stageSelect.SetActive(false);
    }

    // Update is called once per frame
    
    public void GoToSelectScene ()
    {
        MainMenu.SetActive(false);
        stageSelect.SetActive(true);
    }
}
