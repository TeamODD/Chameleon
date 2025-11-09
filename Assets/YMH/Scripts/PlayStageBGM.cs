using UnityEngine;

public class PlayStageBGM : MonoBehaviour
{
    
    [SerializeField] private AudioClip bgmClip;

    
    public void OnClicked()
    {
        if (AudioManager.Instance == null)
        {
            Debug.LogError("AudioManager instance not found!");
            return;
        }

        if (bgmClip == null)
        {
            Debug.LogError("No BGM clip assigned!");
            return;
        }

        // 이미 같은 BGM이 재생 중이면 새로 재생하지 않음
        AudioManager.Instance.PlayBGM(bgmClip);
    }

}
