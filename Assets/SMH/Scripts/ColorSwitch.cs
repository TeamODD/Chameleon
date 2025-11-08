using UnityEngine;

public class ColorSwitch : MonoBehaviour
{
    public int objectColorIndex;
    [SerializeField]
    Transform targetPlatform, arrivePlatform;

    public void SwitchOn()
    {
        targetPlatform.position = Vector2.MoveTowards(targetPlatform.position, arrivePlatform.position, 5f * Time.deltaTime);
    }
}
