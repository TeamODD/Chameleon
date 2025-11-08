using UnityEngine;

public class ColorSwitch : MonoBehaviour
{
    public int objectColorIndex;
    [SerializeField]
    Transform targetPlatform, arrivePoint;

    public void SwitchOn()
    {
        while(targetPlatform.position != arrivePoint.position)
        {
            targetPlatform.position = Vector3.MoveTowards(targetPlatform.position, arrivePoint.position, 5f * Time.deltaTime);
        }
    }
}
