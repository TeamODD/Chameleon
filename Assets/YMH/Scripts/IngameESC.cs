using UnityEngine;
using TMPro;
public class IngameESC : MonoBehaviour
{
    [SerializeField] private GameObject settingPanel;
   
    void Start()
    {
        settingPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            bool isActive = settingPanel.activeSelf;
            settingPanel.SetActive(!isActive);
        }
    }
}
