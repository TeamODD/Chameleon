using UnityEngine;

public class PlayBGM : MonoBehaviour
{
    [SerializeField] private AudioClip bgmClip;

    void Start()
    {
        var audioManager = AudioManager.Instance;

        if (audioManager == null)
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
        audioManager.PlayBGM(bgmClip);
    }
}
/*using UnityEngine;

public class PlayBGM : MonoBehaviour
{
    public AudioClip bgmClip;

    
    void Start()
    {
        var audioManager = AudioManager.Instance;
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

        AudioManager.Instance.PlayBGM(bgmClip);
        AudioSource bgmSource = GetPrivateBGMSource(audioManager);

        
        if (bgmSource != null && bgmSource.isPlaying && bgmSource.clip == bgmClip)
        {
            Debug.Log("같은 BGM이 이미 재생 중이므로 새로 재생하지 않음.");
            return;
        }

        
        audioManager.PlayBGM(bgmClip);
    }

    /// <summary>
    /// AudioManager의 private AudioSource(bgmSource)에 접근하기 위한 유틸 (리플렉션)
    /// AudioManager를 수정하지 않기 위해 사용하는 트릭.
    /// </summary>
    private AudioSource GetPrivateBGMSource(AudioManager audioManager)
    {
        var field = typeof(AudioManager).GetField("bgmSource",
            System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);

        return field?.GetValue(audioManager) as AudioSource;
    }
}

*/