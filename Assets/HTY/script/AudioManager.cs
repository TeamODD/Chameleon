using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance; // singleTone

    [Header("Audio Sources")]
    [SerializeField] private AudioSource bgmSource;
    [SerializeField] private AudioSource sfxSource;

    public float MasterVolume = 1f;
    public float BGMVolume = 1f;
    public float SFXVolume = 1f;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // BGM 재생
    public void PlayBGM(AudioClip clip)
    {
        bgmSource.clip = clip;
        bgmSource.loop = true;
        bgmSource.Play();
    }

    // 효과음 재생
    public void PlaySFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }

    // 볼륨 조절
    public void SetBGMVolume(float volume)
    {
        BGMVolume = volume;
        bgmSource.volume = MasterVolume * BGMVolume;
    }

    public void SetSFXVolume(float volume)
    {
        SFXVolume = volume;
        sfxSource.volume = MasterVolume * SFXVolume;
    }

    public void SetMasterVolume(float volume)
    {
        MasterVolume = volume;
        SetBGMVolume(BGMVolume);
        SetSFXVolume(SFXVolume);
    }
}