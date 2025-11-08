using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToStage : MonoBehaviour
{
    [SerializeField] private int stageNumber;
  
    void Start()
    {
        
    }

   
    void Update()
    {
        
    }
    public void goToStage()
    {
        SceneManager.LoadScene("Stage"+stageNumber);
    }
}
