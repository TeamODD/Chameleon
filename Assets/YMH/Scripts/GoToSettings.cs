using UnityEngine;
using UnityEngine.SceneManagement;


public class GoToSettings : MonoBehaviour
{
    [SerializeField] private GameObject setting;
    [SerializeField] private GameObject MainMenu;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        setting.SetActive(false);
    }

    // Update is called once per frame

    public void GoToSettingScene()
    {
        MainMenu.SetActive(false);
        setting.SetActive(true);
    }
}
