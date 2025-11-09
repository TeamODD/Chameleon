using UnityEngine;
using UnityEngine.SceneManagement;

public class RedObstacleSFX : MonoBehaviour
{
    public AudioClip sfxClip;
    private static bool isSceneChanging = false; // 씬 전환 플래그
    private void Awake()
    {
        // 씬 전환 이벤트 등록
        SceneManager.sceneUnloaded += OnSceneUnloaded;
        SceneManager.activeSceneChanged += OnSceneChanged;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void OnDestroy()
    {
        if (AudioManager.Instance == null)
        {
            return;
        }

        if (sfxClip == null)
        {
            return;
        }
        if (isSceneChanging) return;
        AudioManager.Instance.PlaySFX(sfxClip);
    }
    public static void SetSceneChanging(bool value)
    {
        isSceneChanging = value;
    }
    private void OnSceneUnloaded(Scene scene)
    {
        // 씬이 언로드 시작 → 플래그 true
        isSceneChanging = true;
    }
    private void OnSceneChanged(Scene oldScene, Scene newScene)
    {
        // 씬 로드 완료 후 한 프레임 뒤 플래그 초기화
        GameObject temp = new GameObject("SceneChangeFlagResetter");
        Object.DontDestroyOnLoad(temp);
        temp.AddComponent<SceneChangeReset>().StartReset(() =>
        {
            isSceneChanging = false;
            Object.Destroy(temp);
        });
    }

}
public class SceneChangeReset : MonoBehaviour
{
    public void StartReset(System.Action onDone)
    {
        StartCoroutine(ResetCoroutine(onDone));
    }

    private System.Collections.IEnumerator ResetCoroutine(System.Action onDone)
    {
        yield return null; // 한 프레임 대기
        onDone?.Invoke();
    }
}
