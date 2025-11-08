using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class IngameESC : MonoBehaviour
{
    [SerializeField] private GameObject settingPanel;
    [SerializeField] private GameObject volumePanel;

    void Start()
    {
        settingPanel.SetActive(false);
        volumePanel.SetActive(false);
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (volumePanel.activeSelf)
            {
                volumePanel.SetActive(false);
                settingPanel.SetActive(true);
            }
            else if (settingPanel.activeSelf)
            {
                settingPanel.SetActive(false);
                Time.timeScale = 1f;
            }
            else
            {
                settingPanel.SetActive(true);
                Time.timeScale = 0f;
                //게임 일시정지
            }
        }
        
    }
    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void OpenVolumePanel()
    {
        settingPanel.SetActive(false);
        volumePanel.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("게임 종료"); // 에디터에서는 이 로그로 종료 확인
    }

}
