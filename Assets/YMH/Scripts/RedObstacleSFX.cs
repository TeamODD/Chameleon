using UnityEngine;
using UnityEngine.SceneManagement;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public AudioClip sfxClip;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private static bool isSceneChanging = false;

    private void Awake()
    {
        // 씬이 바뀔 때 호출되는 이벤트 등록
        SceneManager.activeSceneChanged += OnSceneChanged;
    }

    public void OnDestroy()
    {
        

        if (sfxClip == null)
        {
            Debug.LogError("No SFX clip assigned!");
            return;
        }
        if (isSceneChanging) return;
        AudioManager.Instance.PlaySFX(sfxClip);
    }
    private void OnSceneChanged(Scene oldScene, Scene newScene)
    {
        // 씬이 바뀌고 있다는 표시
        isSceneChanging = true;

        // 잠시 뒤 다시 false로 (씬 로드 완료 후)
        // 씬 로드 완료 후에도 계속 true면 다음 Destroy들에 영향 줌
        // => 한 프레임 뒤에 false로 리셋
        // 이건 코루틴으로 구현 가능
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
