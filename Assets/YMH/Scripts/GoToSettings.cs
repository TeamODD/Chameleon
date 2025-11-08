using UnityEngine;
using UnityEngine.SceneManagement;


public class GoToSettings : MonoBehaviour
{
    [SerializeField] private GameObject setting;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        setting.SetActive(false);
    }

    // Update is called once per frame

    public void GoToSettingScene()
    {
        gameObject.SetActive(false);
        setting.SetActive(true);
    }
}
