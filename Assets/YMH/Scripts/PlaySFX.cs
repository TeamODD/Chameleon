using Unity.VisualScripting;
using UnityEngine;

public class PlaySFX : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public AudioClip sfxClip;


    void Start()
    {
       
    }
    public void OnClicked()
    {
        if (AudioManager.Instance == null)
        {
            Debug.LogError("AudioManager instance not found!");
            return;
        }

        if (sfxClip == null)
        {
            Debug.LogError("No SFX clip assigned!");
            return;
        }

        AudioManager.Instance.PlaySFX(sfxClip);
    }

}
