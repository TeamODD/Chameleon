using UnityEngine;

public class PlayBGM : MonoBehaviour
{
    [SerializeField] private AudioClip bgmClip;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        var audio = AudioManager.Instance;
        audio.PlayBGM(bgmClip);
    }

    
}
