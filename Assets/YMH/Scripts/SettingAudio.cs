using UnityEngine;
using UnityEngine.UI;

public class VolumeSliderBinder : MonoBehaviour
{
    public enum VolumeType { Master, BGM, SFX }
    public VolumeType type;

    private Slider slider;

    void Start()
    {
        slider = GetComponent<Slider>();
        if (slider == null)
        {
            Debug.LogError("Slider 컴포넌트를 찾을 수 없습니다!");
            return;
        }

        var audio = AudioManager.Instance;
        if (audio == null)
        {
            Debug.LogError("AudioManager.Instance가 null입니다. AudioManager가 씬에 존재하는지 확인하세요!");
            return;
        }

        // 초기값 반영
        switch (type)
        {
            case VolumeType.Master:
                float masterVolume = audio.MasterVolume;
                slider.value = masterVolume;
                slider.onValueChanged.AddListener(audio.SetMasterVolume);
                break;
            case VolumeType.BGM:
                float bgmVolume = audio.BGMVolume;
                slider.value = audio.BGMVolume;
                slider.onValueChanged.AddListener(audio.SetBGMVolume);
                break;
            case VolumeType.SFX:
                float sfxVolume = audio.SFXVolume;
                slider.value = audio.SFXVolume;
                slider.onValueChanged.AddListener(audio.SetSFXVolume);
                break;
        }
    }
}
