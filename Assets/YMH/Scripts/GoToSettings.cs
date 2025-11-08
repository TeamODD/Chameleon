using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToSettings : MonoBehaviour
{
    public void goToSettingScene()
    {
        SceneManager.LoadScene("Settings");
    }
}
