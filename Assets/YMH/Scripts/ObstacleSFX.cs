using UnityEngine;

public class ObstacleSFX : MonoBehaviour
{
    public AudioClip sfxClip;
    GameObject player;
    PlayerColorLogic pcl;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        pcl = player.GetComponent<PlayerColorLogic>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.F)&& pcl.playerColorIndex == 2)
        {
            Debug.Log($"F pressed, canInterObstacle = {pcl.canInterObstacle}");

            if (pcl.canInterObstacle)
            {
                if (AudioManager.Instance == null)
                {
                    Debug.LogWarning("AudioManager.Instance is null");
                    return;
                }

                if (sfxClip == null)
                {
                    Debug.LogWarning("sfxClip is null");
                    return;
                }
                
                AudioManager.Instance.PlaySFX(sfxClip);
                Debug.Log("SFX played!");
            }
        }
    }
}
